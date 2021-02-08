/*
* Copyright (c) 2019 Samsung Electronics Co., Ltd.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*
*/

using System;
using System.Threading.Tasks;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace HelloWorldTest
{
    class Example : NUIApplication
    {
        private Animation _animation;
        private int cnt;
        private View _view;
        TextField textField;
        TextField newTextField;
        public bool hidden;


        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }


        public void Initialize()
        {
            hidden = true;
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;
            window.Resized += (obj, e) =>
            {
                Tizen.Log.Fatal("NUI", "Height: " + e.WindowSize.Height);
                Tizen.Log.Fatal("NUI", "Width: " + e.WindowSize.Width);
            };

            TextLabel pointLabel;
            pointLabel = new TextLabel("<b>Markup</b> TEST <shadow>SHADOW</shadow>");
            pointLabel.Position2D = new Position2D(10, 10);
            pointLabel.Size2D = new Size2D(400, 60);
            pointLabel.EnableMarkup = true;

            pointLabel.PointSize = 25.0f;
            pointLabel.BackgroundColor = Color.Red;
            window.Add(pointLabel);


            TextLabel label2;
            label2 = new TextLabel("tt <i>Italic</i> TEST <outline>OUTLINE</outline> aa");
            label2.Position2D = new Position2D(10, 110);
            label2.Size2D = new Size2D(400, 60);
            label2.EnableMarkup = true;

            label2.PointSize = 25.0f;
            label2.BackgroundColor = Color.Blue;
            window.Add(label2);


            TextLabel label3;
            label3 = new TextLabel("color <color=yellow>C O L O R</color> test");
            label3.Position2D = new Position2D(10, 210);
            label3.Size2D = new Size2D(400, 60);
            label3.EnableMarkup = true;

            label3.PointSize = 25.0f;
            label3.BackgroundColor = Color.Red;
            window.Add(label3);




            TextLabel label5;
            //label5 = new TextLabel("<item 'url'='icon.png' 'width'=24 'height'=24>Hello</item>");
            //label5 = new TextLabel("Hello <item 'url'='icon.png' 'width'=24 'height'=24/>");

            label5 = new TextLabel("Hello <item 'url'='icon.png' 'width'=24 'height'=24/>");

            label5.Position2D = new Position2D(10, 410);
            label5.Size2D = new Size2D(400, 60);
            label5.EnableMarkup = true;

            label5.PointSize = 25.0f;
            label5.BackgroundColor = Color.White;
            window.Add(label5);






            TextLabel label4;
            //label4 = new TextLabel("<a>www.hyperlink.com</a>");

            //label4 = new TextLabel("<a 'href'='https://google.com'>google</a>");

            label4 = new TextLabel("<b>kknd</b>Hello hihi <a href='https://google.com'>google</a> hihi <b>wonrst..</b>!!! <a href='www.tizen.org'>tizen</a> !!!");
            //label4 = new TextLabel("<a href='https://google.com'/>");

            label4.Position2D = new Position2D(10, 310);
            label4.Size2D = new Size2D(400, 60);
            label4.EnableMarkup = true;

            label4.PointSize = 25.0f;
            label4.BackgroundColor = Color.White;
            window.Add(label4);










/*
            TextLabel label5;
            label5 = new TextLabel("https://google.com");

            label5.Position2D = new Position2D(10, 410);
            label5.Size2D = new Size2D(400, 60);
            label5.TextColor = Color.Cyan;
            
            PropertyMap underline = new PropertyMap();
            underline.Add("enable", new PropertyValue("true"));
            underline.Add("color", new PropertyValue(Color.Cyan));
            underline.Add("height", new PropertyValue(2.0f));
            label5.Underline = underline;

            label5.PointSize = 25.0f;
            label5.BackgroundColor = Color.White;
            window.Add(label5);
*/
        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
