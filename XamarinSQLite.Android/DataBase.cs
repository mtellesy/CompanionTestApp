using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.App;
using Android.Widget;
using Android.OS;
using SQLite.Net.Platform.XamarinAndroid;
using CScore.DataLayer;
using SQLite.Net;
using CScore.DAL;
using CScore.DataLayer.Tables;
using Newtonsoft.Json;
using Newtonsoft;
using Newtonsoft.Json.Converters;
using CScore.SAL;
using CScore.BCL;



namespace XamarinSQLite.Android
{
    [Activity(Label = "XamarinSQLite.Android", Icon = "@drawable/icon")]
    public class Database : Activity
    {
        public Button addButton;


        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            //don't start this activity without pressing login 

            // Set our view from the "database" layout resource
            SetContentView(Resource.Layout.database);
             addButton = FindViewById<Button>(Resource.Id.AddButton);
            var todoListView = FindViewById<ListView>(Resource.Id.TodoListView);
            addButton.Click += OnAddButtonClicked;


            //test
            //What do want to be on your list

            //  List<CScore.BCL.Messages> results = await CScore.DAL.MessageD.getSentMessages(110,20, MainActivity.user_id);

            // don't give a shit about this shit below 
            todoListView.Adapter = new ArrayAdapter<string>(this, global::Android.Resource.Layout.SimpleListItem1);
            var adapter = todoListView.Adapter as ArrayAdapter<string>;
            
        }


        private  async void OnAddButtonClicked(object sender, EventArgs e)
        {

            var todoEditText = FindViewById<EditText>(Resource.Id.TodoEditText);
            var text = todoEditText.Text;


            todoEditText.Text = string.Empty;
            // test 

            //some shit 
            var todoListView = FindViewById<ListView>(Resource.Id.TodoListView);
            var adapter = todoListView.Adapter as ArrayAdapter<string>;
            // end of shit 
            //create your object and fill the info 

            CScore.SAL.AuthenticatorS.domain = "http://192.168.1.2/CStestAPIs";
            //CScore.BCL.StatusWithObject<CScore.BCL.OtherUsers> x = await CScore.BCL.OtherUsers.getOtherUser(211180279);
            // StatusWithObject<String> x = await AuthenticatorS.login(2222,"SSS");
            // text = x.status.status.ToString()+x.status.message;
            User.use_id = 211180279; User.password = "32333";
            Semester.current_term = 3;
            User.use_typeID = "S";
            adapter.Add(User.use_id);

            Messages x = new Messages();
            x.Mes_content = "ddd";
            x.Mes_subject = "dd1d";
            addButton.Enabled = false ;
            Status r = await CScore.BCL.User.login(211180279, "33333444");
            Status z = await CScore.BCL.User.login(211180279, "33333444");
            Status o = await CScore.BCL.User.login(211180279, "33333444");



            adapter.Add(r.status);
           adapter.Add(r.message);
            addButton.Enabled = true;
            //  adapter.Add(r.statusObject);
            //    adapter.Add(r.status.message);
            // if (r.status.status == true && r.statusObject != null)



            //   Course x = r.statusObject[0];

            //     adapter.Add("Course");







        }
    }
}