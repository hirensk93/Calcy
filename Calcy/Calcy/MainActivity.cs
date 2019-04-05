using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;

namespace Calcy
{
    [Activity(Label = "@string/app_name", Theme = "@style/MyTheme", MainLauncher = true,ScreenOrientation =Android.Content.PM.ScreenOrientation.Portrait)]
    public class MainActivity : Activity 
    {
        decimal v1,ans=0;
        String str;
        int ch;
        
       
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            
            EditText text = FindViewById<EditText>(Resource.Id.editText1);
            TextView textView = FindViewById<TextView>(Resource.Id.textView1);
            text.SetCursorVisible(false);

            Button one = FindViewById<Button>(Resource.Id.button_1);
            one.Click += delegate { text.Text += "1"; v1 = Convert.ToDecimal(text.Text); };
            Button two = FindViewById<Button>(Resource.Id.button_2);
            two.Click += delegate { text.Text += "2"; v1 = Convert.ToDecimal(text.Text); };
            Button three = FindViewById<Button>(Resource.Id.button_3);
            three.Click += delegate { text.Text += "3"; v1 = Convert.ToDecimal(text.Text); };
            Button four = FindViewById<Button>(Resource.Id.button_4);
            four.Click += delegate { text.Text += "4"; v1 = Convert.ToDecimal(text.Text); };
            Button five = FindViewById<Button>(Resource.Id.button_5);
            five.Click += delegate { text.Text += "5"; v1 = Convert.ToDecimal(text.Text); };
            Button six = FindViewById<Button>(Resource.Id.button_6);
            six.Click += delegate { text.Text += "6"; v1 = Convert.ToDecimal(text.Text); };
            Button seven = FindViewById<Button>(Resource.Id.button_7);
            seven.Click += delegate { text.Text += "7"; v1 = Convert.ToDecimal(text.Text); };
            Button eight = FindViewById<Button>(Resource.Id.button_8);
            eight.Click += delegate { text.Text += "8"; v1 = Convert.ToDecimal(text.Text); };
            Button nine = FindViewById<Button>(Resource.Id.button_9);
            nine.Click += delegate { text.Text += "9"; v1 = Convert.ToDecimal(text.Text); };
            Button zero = FindViewById<Button>(Resource.Id.button_0);
            zero.Click += delegate { text.Text += "0"; v1 = Convert.ToDecimal(text.Text); };
            Button dot = FindViewById<Button>(Resource.Id.button_dot);
            dot.Click += delegate { if (text.Text.Contains("."))
                {
                    text.Text = text.Text;
                    v1 = Convert.ToDecimal(text.Text);
                }
                else if (text.Text.Equals(""))
                        {
                    text.Text = "0.";
                }
            else
                {
                    text.Text += ".";
                }
                };
            Button del = FindViewById<Button>(Resource.Id.button_del);
            del.Click += delegate { str = text.Text.ToString();text.Text = str.Substring(0, str.Length - 1); };
            Button clr = FindViewById<Button>(Resource.Id.button_c);
            clr.Click += delegate { text.Text = "";textView.Text= ""; };
            Button clre = FindViewById<Button>(Resource.Id.button_ce);
            clre.Click += delegate { text.Text =textView.Text= "";v1 =ans= 0; };
            Button add = FindViewById<Button>(Resource.Id.button_add);
            add.Click += delegate 
            {
                ch = 1;


                if (text.Text.Equals(""))
                {
                    Toast.MakeText(Android.App.Application.Context, "Please Enter Something", ToastLength.Long).Show();

                }
                else if(textView.Text.Equals(""))
                {
                    textView.Text = v1.ToString();
                }
                else
                {
                    v1 = Convert.ToDecimal(text.Text);
                    ans = Convert.ToDecimal(textView.Text) + v1;
                    textView.Text = ans.ToString();
                    
                }
                text.Text = "";

            };
            Button sub = FindViewById<Button>(Resource.Id.button_minus);
            sub.Click += delegate
            {
                ch = 2;
               
               
                if (text.Text.Equals(""))
                {
                    Toast.MakeText(Android.App.Application.Context, "Please Enter Something", ToastLength.Long).Show();

                }
                else if (textView.Text.Equals(""))
                {
                    textView.Text = v1.ToString();
                }
                else
                {
                    v1 = Convert.ToDecimal(text.Text);
                    ans = Convert.ToDecimal(textView.Text) - v1;
                    textView.Text = ans.ToString();
                    

                }
                text.Text = "";
            };
            Button mul = FindViewById<Button>(Resource.Id.button_mul);
            mul.Click += delegate
              {
                  ch = 3;
                 
            
                  if (text.Text.Equals(""))
                  {
                      Toast.MakeText(Android.App.Application.Context, "Please Enter Something", ToastLength.Long).Show();

                  }
                  else if (textView.Text.Equals(""))
                  {
                      textView.Text = v1.ToString();
                  }
                  else
                  {
                      v1 = Convert.ToDecimal(text.Text);
                      ans = Convert.ToDecimal(textView.Text) * v1;
                      textView.Text = ans.ToString();
                     

                  }
                  text.Text = "";

              };
            Button div = FindViewById<Button>(Resource.Id.button_div);
            div.Click += delegate
            {
                ch = 4;
              
              
                if (text.Text.Equals(""))
                {
                    Toast.MakeText(Android.App.Application.Context, "Please Enter Something", ToastLength.Long).Show();

                }
                else if (textView.Text.Equals(""))
                {
                    textView.Text = v1.ToString();
                }
                else
                {
                    try
                    {
                        v1 = Convert.ToDecimal(text.Text);
                        ans = Convert.ToDecimal(textView.Text) / v1;
                        textView.Text = ans.ToString();
                        

                    }
                    catch(ArithmeticException ae)
                    {
                        Toast.MakeText(Android.App.Application.Context, "Divide by Zero"+ae.StackTrace.ToString(), ToastLength.Long).Show();
                    }
                }
                text.Text = "";
            };
            Button eql = FindViewById<Button>(Resource.Id.button_eql);
            eql.Click += delegate
              {
                  ch = 5;
                  textView.Text = ans.ToString();
                  text.Text = "";


              };

            Button per = FindViewById<Button>(Resource.Id.button_per);
            per.Click += delegate
            {
                if (text.Text.Equals(""))
                {
                    Toast.MakeText(Android.App.Application.Context, "Please Enter Something", ToastLength.Long).Show();
                    textView.Text = "Please Enter Something";
                }
                else if (textView.Text.Equals(""))
                {
                    textView.Text = v1.ToString();
                }
                else
                {
                    v1 = Convert.ToDecimal(text.Text);
                    switch(ch)
                    {
                        case 1:
                            ans = Convert.ToDecimal(textView.Text) + ((ans * v1) / 100);
                         
                            textView.Text = ans.ToString();
                           
                            break;
                        case 2:
                            ans = Convert.ToDecimal(textView.Text) - ((ans * v1) / 100);
                            
                            textView.Text = ans.ToString();
                            
                            break;
                        case 3:
                            ans = Convert.ToDecimal(textView.Text) * (v1 / 100);
                            
                            textView.Text = ans.ToString();
                            
                            break;
                        case 4:
                           ans= Convert.ToDecimal(textView.Text) / (v1 / 100);
                           
                            textView.Text = ans.ToString();
                            
                            break;
                        case 5:
                            ans /= 100;
                           
                            textView.Text = ans.ToString();
                           
                            break;
                        default:
                            ans = 0;
                           
                            textView.Text = ans.ToString();
                            break;

                    }
                    
                }
                text.Text = "";

            };

        }
        

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}