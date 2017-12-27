18-bit RGB VGA Palette Serializer
=================================

This is a simple class for reading and writing `System.Drawing.Color` arrays to and from 18-bit RGB VGA palettes.

It has been designed to be either directly referenced in your own projects, or can be used as a serializer with [Cyotek Color Palette Editor](https://www.cyotek.com/cyotek-palette-editor). The class has no dependencies and so the entire class can be embedded in your own code if required.

There is also a small test class to verify the critical bits of the code are doing what they should be.

## Reading Palettes

Palette data can be read from any `Stream`

    RgbTriplets18Serializer reader = new RgbTriplets18Serializer();
    Stream stream = GetDataStream();
    Color[] colors = reader.Load(stream);
    
However, for simplicity an overload is also available to load from a file

    RgbTriplets18Serializer reader = new RgbTriplets18Serializer();
    string fileName = "mypalette.pal";
    Color[] colors = reader.Load(fileName);

You can also use the `CanLoad` overloads to test if a given `Stream` or file contains an 18-bit VGA palette.

## Writing Palettes

As with reading, palette data can be written to either a `Stream` or a file.

    RgbTriplets18Serializer writer = new RgbTriplets18Serializer();
    string fileName = "mypalette.pal";
    Color[] colors = new[] { Color.Red, Color.Green, Color.Blue };
    writer.Save(fileName);


## Further Reading

* [Reading and writing 18-bit RGB VGA Palette (pal) files with C#](https://www.cyotek.com/blog/reading-and-writing-18-bit-rgb-vga-palette-pal-files-with-csharp) is the original blog post describing the format along with screenshots and a demonstration application. This library is derived from that example code.