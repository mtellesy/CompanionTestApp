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
            // end of shit 

        //    if (results != null)
          //  {
            //    for (int k = 0; k < results.Count; k++)
              //      adapter.Add(results[k].mes_content);
            //}
            //end of test 
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

            CScore.SAL.AuthenticatorS.domain = "http://192.168.1.4/CStestAPIs";
            //CScore.BCL.StatusWithObject<CScore.BCL.OtherUsers> x = await CScore.BCL.OtherUsers.getOtherUser(211180279);
            // StatusWithObject<String> x = await AuthenticatorS.login(2222,"SSS");
            // text = x.status.status.ToString()+x.status.message;
            User.use_id =211180279; User.password = "32333";
            StatusWithObject <List<CScore.BCL.Result >> x = await ResultS.getSemesterResult();
            //  StatusWithObject<string> x = await AuthenticatorS.sendRequest("/results/get.php", null, "GET");
            
            text = x.statusCode.ToString()+" " + x.status.status.ToString() + " " + x.status.message + User.use_id ;
         
            adapter.Add(text);
            foreach(CScore.BCL.Result y in x.statusObject)
            {
                adapter.Add(y.Cou_id);

                foreach (MidMarkDistribution z in y.MidExams)
                    {
                    adapter.Add(z.Grade);
                }
                adapter.Add(y.Final);

            }
         
        
                 
            
            //  y= JsonConvert.DeserializeObject<CScore.ResponseObjects.AuthenticationObject>(x.statusObject);
       //      adapter.Add(AuthenticatorS.token);
            //  else
            //    adapter.Add("it was null man");



            // call your save method here to save your object


            //retrive your object here





            //  if (user2 == null)
            //    text = "NULL";

            //end of test

            //  await UsersD.saveUser(text);




        }
    }
}