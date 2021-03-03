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

        public View view;
        public TextLabel label;
        public TextLabel titleLabel;
        public TextLabel artLabel;

        private TapGestureDetector tapGestureDetector;

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        private void OnTapGestureDetected(object source, TapGestureDetector.DetectedEventArgs e)
        {
             Tizen.Log.Error("NUI", "view w " + e.View.Size2D.Width + " view h " + e.View.Size2D.Height + "\n");
        }

        private void LabelOnTapGestureDetected(object source, TapGestureDetector.DetectedEventArgs e)
        {
             Tizen.Log.Error("NUI", "label w " + e.View.Size2D.Width + " label h " + e.View.Size2D.Height + "\n");
        }

        private void View1OnTapGestureDetected(object source, TapGestureDetector.DetectedEventArgs e)
        {
             Tizen.Log.Error("NUI", "view w " + e.View.Size2D.Width + " view h " + e.View.Size2D.Height + "\n");

             float h = view.GetHeightForWidth(400);

             Tizen.Log.Error("NUI", "GetHeightForWidth " + h + "\n");
        }

        private void View2OnTapGestureDetected(object source, TapGestureDetector.DetectedEventArgs e)
        {
             Tizen.Log.Error("NUI", "titleLabel w " + e.View.Size2D.Width + " titleLabel h " + e.View.Size2D.Height + "\n");

             float h = titleLabel.GetHeightForWidth(400);

             Tizen.Log.Error("NUI", "GetHeightForWidth " + h + "\n");
/*
             if (h > 30)
             {
                 //view.Size2D = new Size2D(400, 110);

                 titleLabel.Size2D = new Size2D(400, 60);
                 titleLabel.Text = "Long Long Text Long Long Text Long Long Text Long Long Text Long Long Text Long Long Text Long Long Text";
             }
*/
        }

        private void View3OnTapGestureDetected(object source, TapGestureDetector.DetectedEventArgs e)
        {
             Tizen.Log.Error("NUI", "artLabel w " + e.View.Size2D.Width + " artLabel h " + e.View.Size2D.Height + "\n");

             float h = artLabel.GetHeightForWidth(400);

             Tizen.Log.Error("NUI", "GetHeightForWidth " + h + "\n");

/*
             if (h > 25)
             {
                 //view.Size2D = new Size2D(400, 110);

                 artLabel.Size2D = new Size2D(400, 50);
                 artLabel.Text = "Long Long Text Long Long Text Long Long Text Long Long Text Long Long Text Long Long Text Long Long Text";
             }
*/
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

            view = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    LinearAlignment = LinearLayout.Alignment.Begin,
                    CellPadding = new Size2D(5, 5),
                },
                Margin = new Extents(0, 0, 18, 19),
                HeightResizePolicy = ResizePolicyType.FitToChildren,
                BackgroundColor = Color.Black,
            };

            view.Position2D = new Position2D(10, 310);
            //view.MinimumSize = new Size2D(400, 52);
            //view.MaximumSize = new Size2D(400, 110);
            window.Add(view);

            titleLabel = new TextLabel()
            {
                Text = "Short Text",
                //Text = "Long Long Text Long Long Text Long Long Text Long Long Text Long Long Text Long Long Text Long Long Text",
                //PointSize = 21,
                PointSize = 19,
                MultiLine = true,
                Ellipsis = true,
                BackgroundColor = Color.Cyan,
            };

            //titleLabel.Size2D = new Size2D(400, 60);

            float h = titleLabel.GetHeightForWidth(400);
            Tizen.Log.Error("NUI", "GetHeightForWidth " + h + "\n");
            if (h > 30)
               titleLabel.Size2D = new Size2D(400, 60);
            else
               titleLabel.Size2D = new Size2D(400, 30);


            //titleLabel.MinimumSize = new Size2D(400, 30);
            //titleLabel.MaximumSize = new Size2D(400, 60);
            view.Add(titleLabel);

            artLabel = new TextLabel()
            {
                //Text = "Short Text",
                Text = "Long Long Text Long Long Text Long Long Text Long Long Text Long Long Text Long Long Text Long Long Text",
                //PointSize = 17,
                PointSize = 15,
                MultiLine = true,
                Ellipsis = true,
                BackgroundColor = Color.Red,
            };

            //artLabel.Size2D = new Size2D(400, 50);
            h = artLabel.GetHeightForWidth(400);
            Tizen.Log.Error("NUI", "GetHeightForWidth " + h + "\n");
            if (h > 25)
                artLabel.Size2D = new Size2D(400, 50);
            else
                artLabel.Size2D = new Size2D(400, 25);


            //artLabel.MinimumSize = new Size2D(400, 25);
            //artLabel.MaximumSize = new Size2D(400, 50);
            view.Add(artLabel);


            tapGestureDetector = new TapGestureDetector();
            tapGestureDetector.Attach(view);
            tapGestureDetector.Detected += View1OnTapGestureDetected;
    
            tapGestureDetector = new TapGestureDetector();
            tapGestureDetector.Attach(titleLabel);
            tapGestureDetector.Detected += View2OnTapGestureDetected;

            tapGestureDetector = new TapGestureDetector();
            tapGestureDetector.Attach(artLabel);
            tapGestureDetector.Detected += View3OnTapGestureDetected;


        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
