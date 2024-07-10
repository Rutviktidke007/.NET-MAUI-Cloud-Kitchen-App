//using SQLite;

//Namespaces take the format <ProjectName>.<NamespaceName>
namespace CloudKitchen.Models {
    //Specify the name of the database table to save to
    //[Table("foodItems")]
    public class FoodItem {
        //Create an Id to serve as the primary identifier for each quest
        //AutoIncrement means that SQLite will manage this value for us, 
        //automatically making sure each model has a unique id
        //[PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        //Limit the length of the description to 1000 characters
        //[MaxLength(1000)]
        public string Description { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string ImageSource { get; set; }
        public double PinLatitude { get; set; }
        public double PinLongitude { get; set; }
    }
}