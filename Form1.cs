using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;

namespace WeatherAppFinal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string APIKey = "3330da8966a4c91edbb38eac46bc6e0b";

        private void btnSearch_Click(object sender, EventArgs e)
        {
            getWeather();
        }
        private void btnSearch2_Click(object sender, EventArgs e)
        {
            getWeather2();
        }
        private void btnBoth_Click(object sender, EventArgs e)
        {
            getWeather();
            getWeather2();
        }
        void getWeather()
        {
            using (WebClient web =  new WebClient())
            {
                string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}", txtCity1.Text, APIKey);
                var json = web.DownloadString(url);
                WeatherInformation.root Info = JsonConvert.DeserializeObject<WeatherInformation.root>(json);
                picIcon.ImageLocation = "https://openweathermap.org/img/w/" + Info.weather[0].icon +".png";
                lblCondition.Text = Info.weather[0].main;
                lblDetails.Text = Info.weather[0].description;
                lblSunRiseDetails.Text = Info.sys.sunrise.ToString();
                lblSunSetDetails.Text = Info.sys.sunset.ToString();
                lblWindSpdDetails.Text = Info.wind.speed.ToString();
                lblHumidityDetails.Text = Info.main.humidity.ToString();
            }
        }
        void getWeather2()
        {
            using (WebClient web = new WebClient())
            {
                string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}", txtCity2.Text, APIKey);
                var json = web.DownloadString(url);
                WeatherInformation.root Info = JsonConvert.DeserializeObject<WeatherInformation.root>(json);
                picIcon2.ImageLocation = "https://openweathermap.org/img/w/" + Info.weather[0].icon + ".png";
                lblCondition2.Text = Info.weather[0].main;
                lblDetails2.Text = Info.weather[0].description;
                lblSunRiseDetails2.Text = Info.sys.sunrise.ToString();
                lblSunSetDetails2.Text = Info.sys.sunset.ToString();
                lblWindSpdDetails2.Text = Info.wind.speed.ToString();
                lblHumidityDetails2.Text = Info.main.humidity.ToString();
            }
        }


    }
}
