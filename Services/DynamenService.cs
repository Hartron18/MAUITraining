using MAUITraining.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUITraining.Services
{
    public class DynamenService
    {
        static DynamenService _instance;

        public static DynamenService Instance
        {
            get {  return _instance ??= new DynamenService();}
        }

        public List<DynamenItem> GetDynamenItems()
        {
            var menus = new List<DynamenItem> 
            {
                new DynamenItem()
                {
                    MenuCode="MenuLevel1",
                    Description="Menu 1 Description",
                    ImageSource="",
                    RouteTo="",
                    Title="Menu 1",
                    SortOrder=1,
                    DetailMenuItems=null,
                },
                new DynamenItem()
                {
                    MenuCode="MenuLevel2",
                    Description="Menu 2 Description",
                    ImageSource="",
                    RouteTo="",
                    Title="Menu 2",
                    SortOrder=2,
                    DetailMenuItems=null,
                },
                new DynamenItem()
                {
                    MenuCode="MenuLevel3",
                    Description="Menu 3 Description",
                    ImageSource="",
                    RouteTo="",
                    Title="Menu 3",
                    SortOrder=3,
                    DetailMenuItems=null,
                },
                new DynamenItem()
                {
                    MenuCode="MenuLevel4",
                    Description="Menu 4 Description",
                    ImageSource="",
                    RouteTo="",
                    Title="Menu 4",
                    SortOrder=4,
                    DetailMenuItems=null,
                },
                 new DynamenItem()
                {
                    MenuCode="MenuLevel5",
                    Description="Menu 5 Description",
                    ImageSource="",
                    RouteTo="",
                    Title="Menu 5",
                    SortOrder=5,
                    DetailMenuItems=null,
                },
                 new DynamenItem()
                {
                    MenuCode="MenuLevel6",
                    Description="Menu 6 Description",
                    ImageSource="",
                    RouteTo="",
                    Title="Menu 6",
                    SortOrder=6,
                    DetailMenuItems=null,
                },
                new DynamenItem()
                {
                    MenuCode="MenuLevel7",
                    Description="Menu 7 Description",
                    ImageSource="",
                    RouteTo="",
                    Title="Menu 7",
                    SortOrder=7,
                    DetailMenuItems=null,
                },
                new DynamenItem()
                {
                    MenuCode="MenuLevel8",
                    Description="Menu 8 Description",
                    ImageSource="",
                    RouteTo="",
                    Title="Menu 8",
                    SortOrder=8,
                    DetailMenuItems=null,
                },
                new DynamenItem()
                {
                    MenuCode="MenuLevel9",
                    Description="Menu 9 Description",
                    ImageSource="",
                    RouteTo="",
                    Title="Menu 9",
                    SortOrder=9,
                    DetailMenuItems=null,
                },
                 new DynamenItem()
                {
                    MenuCode="MenuLevel10",
                    Description="Menu 10 Description",
                    ImageSource="",
                    RouteTo="",
                    Title="Menu 10",
                    SortOrder=10,
                    DetailMenuItems=null,
                }
            };

            return menus;
        }

        public static string Title => "Main Menu";
    }
}
