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
            
            List<CScore.BCL.Messages> results = await CScore.DAL.MessageD.getSentMessages(110,20, MainActivity.user_id);

           // don't give a shit about this shit below 
            todoListView.Adapter = new ArrayAdapter<string>(this, global::Android.Resource.Layout.SimpleListItem1);
            var adapter = todoListView.Adapter as ArrayAdapter<string>;
            // end of shit 

            if (results != null)
            {
                for (int k = 0; k < results.Count; k++)
                    adapter.Add(results[k].mes_content);
            }
            //end of test 
        }


        private async void OnAddButtonClicked(object sender, EventArgs e)
        {

            var todoEditText = FindViewById<EditText>(Resource.Id.TodoEditText);
            var text = todoEditText.Text;
         
            todoEditText.Text = string.Empty;
            // test 

            //create your object and fill the info 
            CScore.BCL.Messages message = new CScore.BCL.Messages();
           message.mes_id = MainActivity.i;
            message.mes_content = text;
            message.mes_sender = MainActivity.user_id;

            // call your save method here to save your object
            await CScore.DAL.MessageD.saveMessage(message);

            //retrive your object here
            CScore.BCL.Messages results = await MessageD.getMessage(MainActivity.i++);

            //some shit 
            var todoListView = FindViewById<ListView>(Resource.Id.TodoListView);
            var adapter = todoListView.Adapter as ArrayAdapter<string>;
            // end of shit 

            if (results != null)
            adapter.Add(results.mes_content);
            else
                adapter.Add("it was null man");
          //  if (user2 == null)
            //    text = "NULL";

            //end of test
     
          //  await UsersD.saveUser(text);

           
         
          
        }
    }
}