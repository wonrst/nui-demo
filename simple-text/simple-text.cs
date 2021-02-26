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




            TextField label5;
            //label5 = new TextLabel("<item 'url'='icon.png' 'width'=24 'height'=24>Hello</item>");
            //label5 = new TextLabel("Hello <item 'url'='icon.png' 'width'=24 'height'=24/>");

            label5 = new TextField();
            //label5.Text = "<a href='https://www.google.com'>google</a>";
            label5.Text = "<a href='https://www.tizen.org'>TIZEN</a>";
            //label5.Text = "hello <a href='https://www.naver.com'>naver</a>thisisisi<b>kknd</b>Hello hihi <a href='https://google.com'>google</a>hihi <b>wonrst..</b>!!! <a href='www.tizen.org'>tizen</a> !!!";
            //label5.Text = "<a href='https://www.naver.com'>naver</a>thisisisi<b>kknd</b>Hello hihi <a href='https://google.com'>google</a>hihi <b>wonrst..</b>!!! <a href='www.tizen.org'>tizen</a> !!!";
            
            label5.Position2D = new Position2D(10, 410);
            label5.Size2D = new Size2D(400, 60);
            label5.EnableMarkup = true;
            label5.MaxLength = 100;

            label5.PointSize = 25.0f;
            label5.BackgroundColor = Color.Yellow;

            label5.AnchorTouched += textFieldAnchorTouched;

            window.Add(label5);




            View view = new View();
            view.HeightResizePolicy = ResizePolicyType.FitToChildren;
            view.Position2D = new Position2D(10, 310);
            view.MinimumSize = new Size2D(400, 30);
            view.MaximumSize = new Size2D(400, 100);
            view.BackgroundColor = Color.Cyan;
            window.Add(view);


            TextLabel label4;
            //label4 = new TextLabel("<a>www.hyperlink.com</a>");

            //label4 = new TextLabel("<a href='https://www.google.com'>google</a>");

            //label4 = new TextLabel("<a href='https://review.tizen.org/gerrit/#/c/platform/core/uifw/dali-toolkit/+/252201/'>gogle</a>");


            label4 = new TextLabel("hello <a href='https://www.naver.com'>naver</a> thisisisi <b>kknd</b>Hello hihi <a href='https://google.com'>google</a>hihi <b> wonrst.. </b>!!! <a href='www.tizen.org'>tizen</a> !!!");
            //label4 = new TextLabel("<a href='https://google.com'/>");

            //label4.Position2D = new Position2D(10, 310);
            //label4.Size2D = new Size2D(400, 100);
            label4.EnableMarkup = true;
            label4.PointSize = 17.0f;
            label4.BackgroundColor = Color.Red;
            label4.AnchorTouched += textLabelAnchorTouched;
            //label4.Size2D = new Size2D(400, 10);
            //label4.MinimumSize = new Size2D(400, 30);
            //label4.MaximumSize = new Size2D(400, 200);

            label4.Ellipsis = true;
            label4.MultiLine = true;

            view.Add(label4);

            label4.AnchorTouched += (sender, e) =>
            {
                Tizen.Log.Error("NUI", "view size " + view.Size2D.Width + " " + view.Size2D.Height + "\n");
            };

            Tizen.Log.Error("NUI", "LABEL size " + label4.Size2D.Width + " " + label4.Size2D.Height + "\n");
            Tizen.Log.Error("NUI", "natural size " + label4.GetNaturalSize().Width + " " + label4.GetNaturalSize().Height + "\n");

            if (label4.GetNaturalSize().Width < 400)
              label4.Size2D = new Size2D(400, 30);

            else if (label4.GetNaturalSize().Width >= 400)
              label4.Size2D = new Size2D(400, 60);



        /// - enable (bool type) : True to enable the text fit or false to disable(the default value is false)<br />
        /// - minSize (float type) : Minimum Size for text fit(the default value is 10.f)<br />
        /// - maxSize (float type) : Maximum Size for text fit(the default value is 100.f)<br />
        /// - stepSize (float type) : Step Size for font increase(the default value is 1.f)<br />
        /// - fontSize (string type) 

/*
            PropertyMap textFit = new PropertyMap();
            textFit.Add("enable", new PropertyValue("true"));
            textFit.Add("minSize", new PropertyValue(10.0f));
            textFit.Add("maxSize", new PropertyValue(100.0f));
            label4.TextFit = textFit;
*/
/*
            label4.AnchorTouched += (sender, e) =>
            {
               Tizen.Log.Info("NUI", e.Href + "\n");
               Tizen.Log.Info("NUI", e.HrefLength + "\n");
            };


            window.Add(label4);
*/

            TextEditor label6;
            label6 = new TextEditor();
            //label5.Text = "<a href='https://www.google.com'>google</a>";
            label6.Text = "hello <a href='https://www.naver.com'>naver</a>thisisisi<b>kknd</b>Hello hihi <a href='https://google.com'>google</a>hihi <b>wonrst..</b>!!! <a href='www.tizen.org'>tizen</a> 2312329183210 wewkmkewmekwqmekwqmf wqemkqwemkwm <a>TEST</a> hell.... <a href='wonrst.com'>wonrst</a> qwerdf";
            label6.Position2D = new Position2D(10, 510);
            label6.Size2D = new Size2D(400, 300);
            label6.EnableMarkup = true;


/*
            label6.Text = "statement";
            label6.Position2D = new Position2D(10, 510);
            label6.Size2D = new Size2D(70, 300);
*/
            label6.PointSize = 25.0f;
            label6.BackgroundColor = Color.Green;

            label6.AnchorTouched += textEditorAnchorTouched;
            label6.LineWrapMode = LineWrapMode.Word;
            
            window.Add(label6);







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

        private void textLabelAnchorTouched(object sender, TextLabel.AnchorTouchedEventArgs e)
        {
            Tizen.Log.Error("NUI", "LABEL Anchor TEXT[" + e.TextLabel.Text + "] \n");
            Tizen.Log.Error("NUI", "LABEL Anchor HREF[" + e.Href + "] \n");
            Tizen.Log.Error("NUI", "LABEL Anchor HREF Len[" + e.HrefLength + "] \n");


            Tizen.Log.Error("NUI", "LABEL size " + e.TextLabel.Size2D.Width + " " + e.TextLabel.Size2D.Height + "\n");
            Tizen.Log.Error("NUI", "natural size " + e.TextLabel.GetNaturalSize().Width + " " + e.TextLabel.GetNaturalSize().Height + "\n");
        }

        private void textFieldAnchorTouched(object sender, TextField.AnchorTouchedEventArgs e)
        {
            Tizen.Log.Error("NUI", "FIELD Anchor TEXT[" + e.TextField.Text + "] \n");
            Tizen.Log.Error("NUI", "FIELD Anchor HREF[" + e.Href + "] \n");
            Tizen.Log.Error("NUI", "FIELD Anchor HREF Len[" + e.HrefLength + "] \n");
        }

        private void textEditorAnchorTouched(object sender, TextEditor.AnchorTouchedEventArgs e)
        {
            Tizen.Log.Error("NUI", "EDITOR Anchor TEXT[" + e.TextEditor.Text + "] \n");
            Tizen.Log.Error("NUI", "EDITOR Anchor HREF[" + e.Href + "] \n");
            Tizen.Log.Error("NUI", "EDITOR Anchor HREF Len[" + e.HrefLength + "] \n");

            Tizen.Log.Error("NUI", "EDITOR size " + e.TextEditor.Size2D.Width + " " + e.TextEditor.Size2D.Height + "\n");
            Tizen.Log.Error("NUI", "natural size " + e.TextEditor.GetNaturalSize().Width + " " + e.TextEditor.GetNaturalSize().Height + "\n");
        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
