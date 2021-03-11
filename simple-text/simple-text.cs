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
            editor.Text = "Hello World";
            editor.Size2D = new Size2D(400, 500);
            editor.Position2D = new Position2D(10, 150);
            editor.PointSize = 30.0f;
            window.Add(editor);

            //editor.PrimaryCursorPosition = 0;
            editor.SelectedTextStart = 0;
            editor.SelectedTextEnd = 4;
            Tizen.Log.Fatal("NUI", "START cursor : " + editor.PrimaryCursorPosition + " select : " + editor.SelectedTextStart + " ~ " + editor.SelectedTextEnd + "\n");


            Button button = new Button();
            button.Size2D = new Size2D(50, 50);
            button.Position2D = new Position2D(10, 10);
            button.Clicked += (obj, e) =>
            {                
                editor.SelectedTextStart = 0;
                editor.SelectedTextEnd = 4;
                Tizen.Log.Fatal("NUI", "cursor : " + editor.PrimaryCursorPosition + " select : " + editor.SelectedTextStart + " ~ " + editor.SelectedTextEnd + "\n");
            };
            window.Add(button);

            button = new Button();
            button.Size2D = new Size2D(50, 50);
            button.Position2D = new Position2D(70, 10);
            button.Clicked += (obj, e) =>
            {
                editor.SelectedTextStart ++;
                editor.SelectedTextEnd ++;
                Tizen.Log.Fatal("NUI", "cursor : " + editor.PrimaryCursorPosition + " select : " + editor.SelectedTextStart + " ~ " + editor.SelectedTextEnd + "\n");
            };
            window.Add(button);

            button = new Button();
            button.Size2D = new Size2D(50, 50);
            button.Position2D = new Position2D(130, 10);
            button.Clicked += (obj, e) =>
            {
                editor.SelectedTextStart = editor.PrimaryCursorPosition;
                editor.SelectedTextEnd = editor.PrimaryCursorPosition;
                Tizen.Log.Fatal("NUI", "cursor : " + editor.PrimaryCursorPosition + " select : " + editor.SelectedTextStart + " ~ " + editor.SelectedTextEnd + "\n");
            };
            window.Add(button);



            editor = new TextEditor();
            editor.Text = "Second text editor";
            editor.Size2D = new Size2D(400, 500);
            editor.Position2D = new Position2D(10, 700);
            editor.PointSize = 30.0f;
            window.Add(editor);

            //editor.PrimaryCursorPosition = 0;
            editor.SelectedTextStart = 0;
            editor.SelectedTextEnd = 4;

        }        

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
