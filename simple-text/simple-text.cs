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

        private TapGestureDetector tapGestureDetector;

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
            //TestLog();
        }

/*
        public void TestLog()
        {
            Tizen.Log.Error("NUI", "view w " + view.Size2D.Width + " view h " + view.Size2D.Height + "\n");
        }
*/

        private void OnTapGestureDetected(object source, TapGestureDetector.DetectedEventArgs e)
        {
             Tizen.Log.Error("NUI", "view w " + e.View.Size2D.Width + " view h " + e.View.Size2D.Height + "\n");
        }

        private void LabelOnTapGestureDetected(object source, TapGestureDetector.DetectedEventArgs e)
        {
             Tizen.Log.Error("NUI", "label w " + e.View.Size2D.Width + " label h " + e.View.Size2D.Height + "\n");
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

            View view = new View();
            view.HeightResizePolicy = ResizePolicyType.FitToChildren;
            view.Position2D = new Position2D(10, 310);
            //view.Margin = new Extents(0, 0, 18, 19);

            view.Padding = new Extents(10, 10, 10, 10);

            //view.Size2D = new Size2D(400, 30);

            view.MinimumSize = new Size2D(400, 52);
            view.MaximumSize = new Size2D(400, 110);


            tapGestureDetector = new TapGestureDetector();
            tapGestureDetector.Attach(view);
            tapGestureDetector.Detected += OnTapGestureDetected;

            view.BackgroundColor = Color.Cyan;
            /*
            
            view.Layout = new LinearLayout()
            {
                LinearOrientation = LinearLayout.Orientation.Vertical,
            };
            */
            window.Add(view);


            TextLabel label4;
            label4 = new TextLabel("short text");
            //label4 = new TextLabel("HELLOOOOOOOO5341 2 32");
            //label4 = new TextLabel("middle text middle text middle text middle text middle text middle text ");
            //label4 = new TextLabel("long text long text long text long text long text long text long text long text long text long text long text long text long text long text long text long text long text long text long text long text long text long text long text long text long text long text long text long text ");

            //label4.WidthSpecification = LayoutParamPolicies.MatchParent;
            //label4.HeightSpecification = LayoutParamPolicies.MatchParent;

            //label4.Position2D = new Position2D(10, 310);
            //label4.Size2D = new Size2D(400, 30);
            //label4.EnableMarkup = true;
            label4.PointSize = 17.0f;
            label4.BackgroundColor = Color.Red;
            label4.MinimumSize = new Size2D(200, 30);
            label4.MaximumSize = new Size2D(400, 60);
            //label4.AnchorTouched += textLabelAnchorTouched;
            //label4.Size2D = new Size2D(400, 10);
            //label4.MinimumSize = new Size2D(400, 30);
            //label4.MaximumSize = new Size2D(400, 200);

            label4.MultiLine = true;
            label4.Ellipsis = true;
            //label4.Ellipsis = false;

            float h = label4.GetHeightForWidth(300);
            Tizen.Log.Error("NUI", "GetHeightForWidth " + h + "\n");


            tapGestureDetector = new TapGestureDetector();
            tapGestureDetector.Attach(label4);
            tapGestureDetector.Detected += LabelOnTapGestureDetected;



            view.Add(label4);

/*
            label4.AnchorTouched += (sender, e) =>
            {
                Tizen.Log.Error("NUI", "view size " + view.Size2D.Width + " " + view.Size2D.Height + "\n");
            };
*/
            Tizen.Log.Error("NUI", "LABEL size " + label4.Size2D.Width + " " + label4.Size2D.Height + "\n");
            Tizen.Log.Error("NUI", "natural size " + label4.GetNaturalSize().Width + " " + label4.GetNaturalSize().Height + "\n");

/*
            if (label4.GetNaturalSize().Width < 400)
              label4.Size2D = new Size2D(400, 30);
s
            else if (label4.GetNaturalSize().Width >= 400)
              label4.Size2D = new Size2D(400, 60);
*/


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

        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
