// Cyotek 18-bit RGB VGA Palette Serializer
// Copyright (c) 2017 Cyotek Ltd.
// https://www.cyotek.com

// Licensed under the MIT License. See license.txt for the full text.

// If you find this code useful please consider making a donation.

using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;

// For Cyotek Color Palette Editor to detect this class as a serializer without having to take
// dependencies on other Cyotek libraries the following conditions must be met
//
// * The class must be public and not abstract
// * The class name must end in Serializer
// * There must be an instance of DescriptionAttribute on the class with a simple name for use in file filters
// * There must be a readable property named Extensions of type string[]
// * To enable load support, the following are required
// *   A method named CanLoad, that accepts a Stream and returns a bool
// *   A method named Load, that accepts a Stream and returns Color[]
// * To enable save support, the following are required
// *   A method named Save, that accepts a Stream and Color[] and returns void
//
// Methods and properties can be public or private.
//
// Cyotek Color Palette Editor 1.7 and above can load serializers following the above rules,
// older versions can only load ones that are explicity inheriting a more complicated base class.
// The ability to specific advanced functionality such as minimum/maximum counts, color types,
// etc are not available from this simplified form.
//
// The Load(String) and Save(String) overloads are convenience helpers for consumers of
// the class and are not directly used by Cyotek Color Palette Editor.

namespace Cyotek.Drawing.PaletteFormat
{
  [Description("18-bit RGB VGA Palette")]
  public sealed class RgbTriplets18Serializer
  {
    #region Constants

    private const string _invalidDataMessage = "Stream does not contain 18-bit RGB triplets.";

    #endregion

    #region Properties

    public string[] Extensions
    {
      get
      {
        return new[]
               {
                 "pal"
               };
      }
    }

    #endregion

    #region Methods

    public bool CanLoad(Stream stream)
    {
      bool result;
      int length;
      result = false;

      if (stream == null)
      {
        throw new ArgumentNullException(nameof(stream));
      }

      length = (int)stream.Length;

      if (length % 3 == 0)
      {
        byte[] buffer;

        buffer = this.LoadBuffer(stream);

        if (buffer != null)
        {
          result = true;

          for (int i = 0; i < length; i++)
          {
            // 6-bit values are in the range 0-63, anything higher clearly can't be valid
            if (buffer[i] > 63)
            {
              result = false;
              break;
            }
          }
        }
      }

      return result;
    }

    public bool CanLoad(string fileName)
    {
      if (string.IsNullOrEmpty(fileName))
      {
        throw new ArgumentNullException(nameof(fileName));
      }

      if (!File.Exists(fileName))
      {
        throw new FileNotFoundException("Cannot find file '" + fileName + "'.", fileName);
      }

      using (Stream stream = File.OpenRead(fileName))
      {
        return this.CanLoad(stream);
      }
    }

    public Color[] Load(Stream stream)
    {
      int length;
      int count;
      byte[] buffer;
      Color[] results;

      if (stream == null)
      {
        throw new ArgumentNullException(nameof(stream));
      }

      length = (int)stream.Length;

      if (length % 3 != 0)
      {
        throw new InvalidDataException(_invalidDataMessage);
      }

      buffer = this.LoadBuffer(stream);

      if (buffer == null)
      {
        throw new InvalidDataException(_invalidDataMessage);
      }

      count = length / 3;
      results = new Color[count];

      for (int i = 0; i < count; i++)
      {
        int index;
        int r;
        int g;
        int b;

        index = i * 3;
        r = buffer[index];
        g = buffer[index + 1];
        b = buffer[index + 2];

        if (r > 63 || g > 63 || b > 63)
        {
          throw new InvalidDataException(_invalidDataMessage);
        }

        results[i] = Color.FromArgb(r * 255 / 63, g * 255 / 63, b * 255 / 63);
      }

      return results;
    }

    public Color[] Load(string fileName)
    {
      if (string.IsNullOrEmpty(fileName))
      {
        throw new ArgumentNullException(nameof(fileName));
      }

      if (!File.Exists(fileName))
      {
        throw new FileNotFoundException("Cannot find file '" + fileName + "'.", fileName);
      }

      using (Stream stream = File.OpenRead(fileName))
      {
        return this.Load(stream);
      }
    }

    public void Save(string fileName, Color[] values)
    {
      if (string.IsNullOrEmpty(fileName))
      {
        throw new ArgumentNullException(nameof(fileName));
      }

      if (values == null)
      {
        throw new ArgumentNullException(nameof(values));
      }

      using (Stream stream = File.Create(fileName))
      {
        this.Save(stream, values);
      }
    }

    public void Save(Stream stream, Color[] values)
    {
      int length;

      if (stream == null)
      {
        throw new ArgumentNullException(nameof(stream));
      }

      if (values == null)
      {
        throw new ArgumentNullException(nameof(values));
      }

      length = values.Length * 3;

      if (length > 0)
      {
        byte[] buffer;

        buffer = new byte[length];

        for (int i = 0; i < values.Length; i++)
        {
          Color color;
          int index;

          index = i * 3;
          color = values[i];

          buffer[index] = (byte)(color.R * 63 / 255);
          buffer[index + 1] = (byte)(color.G * 63 / 255);
          buffer[index + 2] = (byte)(color.B * 63 / 255);
        }

        stream.Write(buffer, 0, length);
      }
    }

    private byte[] LoadBuffer(Stream stream)
    {
      int length;
      byte[] buffer;
      bool readSuccessful;

      length = (int)stream.Length;
      buffer = new byte[length];

      readSuccessful = stream.Read(buffer, 0, length) == length;

      return readSuccessful ? buffer : null;
    }

    #endregion
  }
}
