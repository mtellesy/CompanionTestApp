using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
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


        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            //don't start this activity without pressing login 

            // Set our view from the "database" layout resource
            SetContentView(Resource.Layout.database);
            var addButton = FindViewById<Button>(Resource.Id.AddButton);
            var todoListView = FindViewById<ListView>(Resource.Id.TodoListView);
            addButton.Click += OnAddButtonClicked;


            //test
            //What do want to be on your list

            //  List<CScore.BCL.Messages> results = await CScore.DAL.MessageD.getSentMessages(110,20, MainActivity.user_id);

            // don't give a shit about this shit below 
            todoListView.Adapter = new ArrayAdapter<string>(this, global::Android.Resource.Layout.SimpleListItem1);
            var adapter = todoListView.Adapter as ArrayAdapter<string>;
            
        }


        private async void OnAddButtonClicked(object sender, EventArgs e)
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

            CScore.SAL.AuthenticatorS.domain = "http://192.168.1.3/CStestAPIs";
            //CScore.BCL.StatusWithObject<CScore.BCL.OtherUsers> x = await CScore.BCL.OtherUsers.getOtherUser(211180279);
            // StatusWithObject<String> x = await AuthenticatorS.login(2222,"SSS");
            // text = x.status.status.ToString()+x.status.message;
            User.use_id = 211180279; User.password = "32333";
            User.use_typeID = "S";
            adapter.Add(User.use_id);

            Announcements y = new Announcements();
            y.Ano_content = "DDDDD";
            y.Ano_sender = User.use_id;
            y.Ano_time = DateTime.UtcNow.ToString();
            y.Cou_id = "ITG100";
            y.ReferenceID = "444";
            y.Ter_id = 3;

            StatusWithObject<Announcements> r = await CScore.BCL.Announcements.sendAnnouncement(y);
            adapter.Add(r.status.status);
            adapter.Add(r.status.message);

       
            Announcements x = r.statusObject;
            
                adapter.Add("ANo");
                adapter.Add(x.Ter_id);
            adapter.Add(x.Ano_id);
            adapter.Add(x.Cou_id);
                adapter.Add(x.Ano_content);
                adapter.Add(x.Ano_sender);
            adapter.Add("END");
            



        }
    }
}