﻿// Cyotek 18-bit RGB VGA Palette Serializer
// Copyright (c) 2017 Cyotek Ltd.
// https://www.cyotek.com

// Licensed under the MIT License. See license.txt for the full text.

// If you find this code useful please consider making a donation.

using System;
using System.Drawing;
using System.IO;
using NUnit.Framework;

namespace Cyotek.Drawing.PaletteFormat.Tests
{
  [TestFixture]
  public class RgbTriplets18SerializerTests
  {
    #region  Tests

    [Test]
    public void CanLoad_With18bitData_IsTrue()
    {
      // arrange
      RgbTriplets18Serializer target;
      Stream data;
      bool actual;

      data = new MemoryStream(Data);

      target = new RgbTriplets18Serializer();

      // act
      actual = target.CanLoad(data);

      // assert
      Assert.IsTrue(actual);
    }

    [Test]
    public void CanLoad_With24bitData_IsFalse()
    {
      // arrange
      RgbTriplets18Serializer target;
      Stream data;
      bool actual;

      data = new MemoryStream(new byte[]
                              {
                                0,
                                0,
                                0,
                                255,
                                255,
                                255
                              });

      target = new RgbTriplets18Serializer();

      // act
      actual = target.CanLoad(data);

      // assert
      Assert.IsFalse(actual);
    }

    [Test]
    public void CanLoad_WithFileName_IsTrue()
    {
      // arrange
      RgbTriplets18Serializer target;
      bool actual;
      string fileName;

      fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"data\sample.pal");

      target = new RgbTriplets18Serializer();

      // act
      actual = target.CanLoad(fileName);

      // assert
      Assert.IsTrue(actual);
    }

    [Test]
    public void CanLoad_WithMisalignedData_IsFalse()
    {
      // arrange
      RgbTriplets18Serializer target;
      Stream data;
      bool actual;

      data = new MemoryStream(new byte[]
                              {
                                0,
                                1,
                                2,
                                4,
                                8
                              });

      target = new RgbTriplets18Serializer();

      // act
      actual = target.CanLoad(data);

      // assert
      Assert.IsFalse(actual);
    }

    [Test]
    public void Extensions_ReturnsValues()
    {
      // arrange
      RgbTriplets18Serializer target;
      string[] expected;
      string[] actual;

      expected = new[]
                 {
                   "pal"
                 };

      target = new RgbTriplets18Serializer();

      // act
      actual = target.Extensions;

      // assert
      CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Load_With18bitData_ReturnsPalette()
    {
      // arrange
      RgbTriplets18Serializer target;
      Color[] expected;
      Color[] actual;
      Stream data;

      data = new MemoryStream(Data);
      expected = Sample;

      target = new RgbTriplets18Serializer();

      // act
      actual = target.Load(data);

      // assert
      CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Load_WithFileName_ReturnsPalette()
    {
      // arrange
      RgbTriplets18Serializer target;
      Color[] expected;
      Color[] actual;
      string fileName;

      fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"data\sample.pal");
      expected = Sample;

      target = new RgbTriplets18Serializer();

      // act
      actual = target.Load(fileName);

      // assert
      CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Save_WritesValueData()
    {
      // arrange
      RgbTriplets18Serializer target;
      MemoryStream output;
      Color[] data;
      byte[] expected;
      byte[] actual;

      expected = Data;
      output = new MemoryStream();
      data = Sample;

      target = new RgbTriplets18Serializer();

      // act
      target.Save(output, data);

      // assert
      actual = output.ToArray();
      CollectionAssert.AreEqual(expected, actual);
    }

    #endregion

    #region Test Helpers

    private static byte[] Data
    {
      get
      {
        return new byte[]
               {
                 63,
                 23,
                 12,
                 57,
                 21,
                 13,
                 52,
                 16,
                 10,
                 46,
                 11,
                 7,
                 41,
                 7,
                 4,
                 35,
                 4,
                 2,
                 30,
                 1,
                 0,
                 25,
                 0,
                 0,
                 46,
                 49,
                 63,
                 40,
                 44,
                 61,
                 34,
                 40,
                 60,
                 29,
                 36,
                 59,
                 23,
                 32,
                 57,
                 18,
                 29,
                 56,
                 13,
                 26,
                 55,
                 9,
                 23,
                 54,
                 63,
                 63,
                 40,
                 63,
                 63,
                 28,
                 63,
                 63,
                 0,
                 60,
                 57,
                 0,
                 57,
                 53,
                 0,
                 54,
                 47,
                 0,
                 51,
                 43,
                 0,
                 49,
                 39,
                 0,
                 52,
                 63,
                 32,
                 42,
                 60,
                 25,
                 30,
                 58,
                 11,
                 17,
                 56,
                 0,
                 6,
                 50,
                 0,
                 0,
                 43,
                 1,
                 0,
                 37,
                 7,
                 0,
                 31,
                 12,
                 40,
                 40,
                 40,
                 36,
                 36,
                 36,
                 33,
                 33,
                 33,
                 29,
                 29,
                 29,
                 26,
                 26,
                 26,
                 22,
                 22,
                 22,
                 19,
                 19,
                 19,
                 16,
                 16,
                 16,
                 34,
                 34,
                 63,
                 28,
                 28,
                 63,
                 21,
                 21,
                 63,
                 15,
                 15,
                 63,
                 0,
                 0,
                 63,
                 0,
                 0,
                 56,
                 0,
                 0,
                 50,
                 0,
                 0,
                 44,
                 63,
                 30,
                 63,
                 63,
                 0,
                 63,
                 57,
                 0,
                 57,
                 52,
                 0,
                 52,
                 47,
                 0,
                 47,
                 41,
                 0,
                 41,
                 36,
                 0,
                 36,
                 31,
                 0,
                 31,
                 0,
                 63,
                 63,
                 0,
                 57,
                 57,
                 0,
                 52,
                 52,
                 0,
                 47,
                 47,
                 0,
                 42,
                 42,
                 0,
                 37,
                 37,
                 0,
                 32,
                 32,
                 0,
                 27,
                 27,
                 63,
                 29,
                 45,
                 57,
                 22,
                 39,
                 52,
                 17,
                 35,
                 47,
                 12,
                 30,
                 42,
                 7,
                 26,
                 37,
                 4,
                 22,
                 32,
                 1,
                 19,
                 27,
                 0,
                 16,
                 63,
                 46,
                 0,
                 58,
                 41,
                 0,
                 54,
                 37,
                 0,
                 50,
                 33,
                 0,
                 46,
                 30,
                 0,
                 42,
                 26,
                 0,
                 38,
                 23,
                 0,
                 34,
                 20,
                 0,
                 63,
                 63,
                 63,
                 55,
                 55,
                 63,
                 50,
                 50,
                 59,
                 46,
                 46,
                 56,
                 42,
                 42,
                 57,
                 37,
                 37,
                 49,
                 32,
                 32,
                 51,
                 26,
                 26,
                 47,
                 0,
                 51,
                 0,
                 0,
                 46,
                 0,
                 0,
                 42,
                 0,
                 0,
                 38,
                 0,
                 0,
                 34,
                 0,
                 0,
                 30,
                 0,
                 0,
                 26,
                 0,
                 0,
                 22,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0
               };
      }
    }

    private static Color[] Sample
    {
      get
      {
        return new[]
               {
                 Color.FromArgb(252, 92, 48),
                 Color.FromArgb(228, 84, 52),
                 Color.FromArgb(208, 64, 40),
                 Color.FromArgb(184, 44, 28),
                 Color.FromArgb(164, 28, 16),
                 Color.FromArgb(140, 16, 8),
                 Color.FromArgb(120, 4, 0),
                 Color.FromArgb(100, 0, 0),
                 Color.FromArgb(184, 196, 252),
                 Color.FromArgb(160, 176, 244),
                 Color.FromArgb(136, 160, 240),
                 Color.FromArgb(116, 144, 236),
                 Color.FromArgb(92, 128, 228),
                 Color.FromArgb(72, 116, 224),
                 Color.FromArgb(52, 104, 220),
                 Color.FromArgb(36, 92, 216),
                 Color.FromArgb(252, 252, 160),
                 Color.FromArgb(252, 252, 112),
                 Color.FromArgb(252, 252, 0),
                 Color.FromArgb(240, 228, 0),
                 Color.FromArgb(228, 212, 0),
                 Color.FromArgb(216, 188, 0),
                 Color.FromArgb(204, 172, 0),
                 Color.FromArgb(196, 156, 0),
                 Color.FromArgb(208, 252, 128),
                 Color.FromArgb(168, 240, 100),
                 Color.FromArgb(120, 232, 44),
                 Color.FromArgb(68, 224, 0),
                 Color.FromArgb(24, 200, 0),
                 Color.FromArgb(0, 172, 4),
                 Color.FromArgb(0, 148, 28),
                 Color.FromArgb(0, 124, 48),
                 Color.FromArgb(160, 160, 160),
                 Color.FromArgb(144, 144, 144),
                 Color.FromArgb(132, 132, 132),
                 Color.FromArgb(116, 116, 116),
                 Color.FromArgb(104, 104, 104),
                 Color.FromArgb(88, 88, 88),
                 Color.FromArgb(76, 76, 76),
                 Color.FromArgb(64, 64, 64),
                 Color.FromArgb(136, 136, 252),
                 Color.FromArgb(112, 112, 252),
                 Color.FromArgb(84, 84, 252),
                 Color.FromArgb(60, 60, 252),
                 Color.FromArgb(0, 0, 252),
                 Color.FromArgb(0, 0, 224),
                 Color.FromArgb(0, 0, 200),
                 Color.FromArgb(0, 0, 176),
                 Color.FromArgb(252, 120, 252),
                 Color.FromArgb(252, 0, 252),
                 Color.FromArgb(228, 0, 228),
                 Color.FromArgb(208, 0, 208),
                 Color.FromArgb(188, 0, 188),
                 Color.FromArgb(164, 0, 164),
                 Color.FromArgb(144, 0, 144),
                 Color.FromArgb(124, 0, 124),
                 Color.FromArgb(0, 252, 252),
                 Color.FromArgb(0, 228, 228),
                 Color.FromArgb(0, 208, 208),
                 Color.FromArgb(0, 188, 188),
                 Color.FromArgb(0, 168, 168),
                 Color.FromArgb(0, 148, 148),
                 Color.FromArgb(0, 128, 128),
                 Color.FromArgb(0, 108, 108),
                 Color.FromArgb(252, 116, 180),
                 Color.FromArgb(228, 88, 156),
                 Color.FromArgb(208, 68, 140),
                 Color.FromArgb(188, 48, 120),
                 Color.FromArgb(168, 28, 104),
                 Color.FromArgb(148, 16, 88),
                 Color.FromArgb(128, 4, 76),
                 Color.FromArgb(108, 0, 64),
                 Color.FromArgb(252, 184, 0),
                 Color.FromArgb(232, 164, 0),
                 Color.FromArgb(216, 148, 0),
                 Color.FromArgb(200, 132, 0),
                 Color.FromArgb(184, 120, 0),
                 Color.FromArgb(168, 104, 0),
                 Color.FromArgb(152, 92, 0),
                 Color.FromArgb(136, 80, 0),
                 Color.FromArgb(252, 252, 252),
                 Color.FromArgb(220, 220, 252),
                 Color.FromArgb(200, 200, 236),
                 Color.FromArgb(184, 184, 224),
                 Color.FromArgb(168, 168, 228),
                 Color.FromArgb(148, 148, 196),
                 Color.FromArgb(128, 128, 204),
                 Color.FromArgb(104, 104, 188),
                 Color.FromArgb(0, 204, 0),
                 Color.FromArgb(0, 184, 0),
                 Color.FromArgb(0, 168, 0),
                 Color.FromArgb(0, 152, 0),
                 Color.FromArgb(0, 136, 0),
                 Color.FromArgb(0, 120, 0),
                 Color.FromArgb(0, 104, 0),
                 Color.FromArgb(0, 88, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0),
                 Color.FromArgb(0, 0, 0)
               };
      }
    }

    #endregion
  }
}
