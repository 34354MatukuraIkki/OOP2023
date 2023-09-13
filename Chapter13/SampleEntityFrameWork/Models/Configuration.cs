using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleEntityFrameWork.Models {
    internal class Configuration : DbMigrationsConfiguration<BooksDbContext>{
        public Configuration() {
            AutomaticMigrationsEnabled = true;  //自動マイグレーションの有効化
            AutomaticMigrationDataLossAllowed = true;   //データロスを伴う更新を許可
            ContextKey = "SampleEntityFrameWork.Models.BooksDbContext";
        }
    }
}
