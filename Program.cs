using System;
using System.Xml.Serialization;
using System.IO;

public class Program
{
	// Getting path and file
	static string path = @"C:\\Users\\Khalaf Nasirov\\Documents\\Application Development\\Docs\\";
	static string file_name = "new_data.xml";

	static void Main()
	{
		// Saving and reading file as XML

		WriteData();
		ReadData();

	}

	static void WriteData()
	{
		// Data
		Data data = new Data();
		data.name = "data_1";
		data.nums = new int[] { 1, 2, 3 };
		data.size = data.nums.Length;
		data.id = 0;

		// File creating
		FileStream file = File.Create(Path.Combine(path, file_name));

		// Serialization
		XmlSerializer writer = new XmlSerializer(typeof(Data));

		writer.Serialize(file, data);

		file.Close();

		Console.WriteLine("File saved");
	}

	static void ReadData()
	{
		// Data (Empty)
		Data data = new Data();

		// Getting real file 
		StreamReader file = new StreamReader(Path.Combine(path,file_name));

		// Deserialization
		XmlSerializer reader = new XmlSerializer(typeof(Data));

		// Getting data
		data = (Data)reader.Deserialize(file);

		file.Close();

		Console.WriteLine("File loaded");

		Console.WriteLine(data.name);
		Console.WriteLine(data.nums);
		Console.WriteLine(data.size);
		Console.WriteLine(data.id);
	}

	public struct Data
	{
		public string name;
		public int[] nums;
		public int size;
		public int id;
	}
}