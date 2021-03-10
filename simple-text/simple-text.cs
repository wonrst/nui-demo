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
        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        public void Initialize()
        {
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;
            window.Resized += (obj, e) =>
            {
                Tizen.Log.Fatal("NUI", "Height: " + e.WindowSize.Height);
                Tizen.Log.Fatal("NUI", "Width: " + e.WindowSize.Width);
            };

            TextEditor editor = new TextEditor();
            editor.Text = "a\nb\nc\nd\ne\nf\nghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz\n";
            editor.Size2D = new Size2D(400, 500);
            editor.Position2D = new Position2D(10, 150);
            editor.PointSize = 30.0f;
            window.Add(editor);


            Button button = new Button();
            button.Size2D = new Size2D(50, 50);
            button.Position2D = new Position2D(10, 10);
            button.Clicked += (obj, e) =>
            {                
                Tizen.Log.Fatal("NUI", "GetNaturalSize : W " + editor.GetNaturalSize().Width + " H " + editor.GetNaturalSize().Height + "\n");
            };
            window.Add(button);

            button = new Button();
            button.Size2D = new Size2D(50, 50);
            button.Position2D = new Position2D(70, 10);
            button.Clicked += (obj, e) =>
            {                
                Tizen.Log.Fatal("NUI", "Line " + editor.LineCount + "\n");
            };
            window.Add(button);

        }        

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
