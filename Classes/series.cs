using System;

namespace SeriesRegister.Classes
{
    public class series : baseEntity
    {
        private Genre Genre {get; set;}
        private string Title {get; set;}
        private string Description {get; set;}
        private int Year {get; set;}
        private bool Deleted {get; set;}
        
        public series(int Id, Genre Genre, string Title, string Description, int Year){
            this.Id = Id;
            this.Genre = Genre;
            this.Title = Title;
            this.Description = Description;
            this.Year = Year;
            this.Deleted = false;
        }

        public override string ToString()
        {
            string text = "Genre: " + this.Genre + Environment.NewLine;
            text += "Title: " + this.Title + Environment.NewLine;
            text += "Description: " + this.Description + Environment.NewLine;
            text += "Year: " + this.Year + Environment.NewLine;
            text += "Deleted: " + this.Deleted;
            return text;
        }

        public string getTitle(){
            return this.Title;
        }

        public int getId(){
            return this.Id;
        }
        
        public bool getDeleted(){
            return this.Deleted;
        }

        public void Delete(){
            this.Deleted = true;
        }
    }
}