
namespace MAUITraining.Models
{
    public class Note
    {
        public string FileName { get; set; } = "nnotes.txt";
        public string Text { get; set; }
        public DateTime Date { get; set; }

        public void Save() => File.WriteAllText(
           Path.Combine(FileSystem.AppDataDirectory, FileName), Text);

        public void Delete() => File.Delete(
            System.IO.Path.Combine(FileSystem.AppDataDirectory, FileName));

        public static Note Load(string fileName)
        {
            fileName = Path.Combine(FileSystem.AppDataDirectory, fileName);

            if(!File.Exists(fileName)) 
                throw new FileNotFoundException("Unable to find the file on local storage", fileName);

            return new()
            {
                FileName = Path.GetFileName(fileName),
                Text = File.ReadAllText(fileName),
                Date = File.GetCreationTime(fileName)
            };
        }

        public static IEnumerable<Note> LoadAll()
        {

            string appDataPath = FileSystem.AppDataDirectory;

            return Directory
                .EnumerateFiles(appDataPath, "*.notes.txt")
                .Select(fileName => Note.Load(Path.GetFileName(fileName)))
                .OrderByDescending(x => x.Date);
        }
    }
}
