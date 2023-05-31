using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hotelApi.Models
{
    [Table("hoteldata")]
    public class hotelcomponents
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public int price { get; set; }
        public string image { get; set; } = string.Empty;

    }
    public class hotelcomponent : DbContext
    {
       public  DbSet<hotelcomponents> hotel { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string strcon= "Data Source=W-674PY03-1;Initial Catalog=CharanDb;Persist Security Info=True;User ID=sa;Password=Password@12345;TrustServerCertificate=True" ;
            optionsBuilder.UseSqlServer(strcon);
            base.OnConfiguring(optionsBuilder);
        }
    }
    interface Ihotelcharge
    {
        void Additem(hotelcomponents item);
        void Updateitem(hotelcomponents item);
        hotelcomponents Getitem(int id);
        List<hotelcomponents> Getitems();
        void RemoveItem(int id);
    }
    class hoteldata : Ihotelcharge
    {
        public void Additem(hotelcomponents item)
        {
            var context = new hotelcomponent();
            context.hotel.Add(item);
            context.SaveChanges();
        }

        public hotelcomponents Getitem(int id)
        {
            var context = new hotelcomponent();
            var founditem = context.hotel.FirstOrDefault(x=> x.id == id);   
            if(founditem != null)
            {
                return founditem;
            }
            else
            {
                throw new Exception("No item found !");
            }
        }

        public List<hotelcomponents> Getitems()
        {
            var context = new hotelcomponent();
            var items = context.hotel.ToList();
            if(items != null)
            {
                return items;
            }
            else
            {
                throw new Exception("items not found!");
            }
        }

        public void RemoveItem(int id)
        {
            var context = new hotelcomponent();
            var find = context.hotel.FirstOrDefault(x => x.id == id);
            if(find != null)
            {
                context.hotel.Remove(find);
            }
            else
            {
                throw new Exception("No item found!!");
            }

        }

        public void Updateitem(hotelcomponents item)
        {
            var context = new hotelcomponent();
            var data = context.hotel.FirstOrDefault(x => x.id == item.id);
            if(data != null) 
            { 
                data.description = item.description;
                data.Price = item.Price;
                data.name = item.itemName;
                data.image= item.image;
            }
            context.SaveChanges();
        }
    }
}
