using MAUITraining.Models;

namespace MAUITraining.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class NotesPage : ContentPage
{
    public string ItemId
    {
        set { LoadNote(value); }
    }

    public NotesPage()
	{
		InitializeComponent();

        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";

        LoadNote(Path.Combine(appDataPath, randomFileName));
        
    }

    private void LoadNote(string filename)
    {
        Note note = new ();
        note.FileName= filename;

        if (File.Exists(filename))
        {
            note.Date = File.GetCreationTime(filename);
            note.Text= File.ReadAllText(filename);
        }

        BindingContext= note;
    }

    string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");
    

    private void SaveButton_Clicked(object sender, EventArgs e)
    {
        //save the file
        File.WriteAllText(_fileName, TextEditor.Text);
    }

    private void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (File.Exists(_fileName)) File.Delete(_fileName);

        TextEditor.Text = string.Empty;
        
    }
}