using System.Reflection.Metadata.Ecma335;

namespace GradeBook.GradeBooks
{
    public class Tree
    {
        private string _name;
        public int Age { get; set; } 
        public string Country;



        public Tree()
        {
           
        }
    }


    public class Animal
    {
        public string AnimalName;
        public Tree MyTree;

        public string GetTreeName(string treeName)
        {
            if (treeName == "dab")
                MyTree.Age = 40;
            return "dab";
        }



        

    }
}