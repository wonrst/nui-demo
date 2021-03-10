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

namespace HelloWorldTest
{
    class Example : NUIApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        public void onTextChanged(object sender, TextField.TextChangedEventArgs e)
        {
            Tizen.Log.Fatal("NUI", "Text Changed : " + e.TextField.Text + "\n");
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

            TextField textField = new TextField();
            textField.Text = "TextField Ellipsis Test, ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            textField.Size2D = new Size2D(400, 100);
            textField.Position2D = new Position2D(10, 150);
            textField.PointSize = 30.0f;
            textField.Ellipsis = false;
            window.Add(textField);

            textField.TextChanged += (obj, e) =>
            {
                Tizen.Log.Fatal("NUI", "Text Changed : " + e.TextField.Text + "\n");
            };

            TextField textField2 = new TextField();
            textField2.Text = "TextField Ellipsis Test, ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            textField2.Size2D = new Size2D(400, 100);
            textField2.Position2D = new Position2D(10, 300);
            textField2.PointSize = 30.0f;
            textField2.Ellipsis = true;
            window.Add(textField2);

            textField2.TextChanged += onTextChanged;

            TextField textFieldPlaceholderTest = new TextField();

            PropertyMap propertyMap = new PropertyMap();
            propertyMap.Add("placeholderText", new PropertyValue("TextField Placeholder Test"));
            propertyMap.Add("placeholderTextFocused", new PropertyValue("Placeholder Text Focused"));
            propertyMap.Add("placeholderColor", new PropertyValue(Color.Blue));
            propertyMap.Add("placeholderPointSize", new PropertyValue(20.0f));

            PropertyMap fontStyleMap = new PropertyMap();
            fontStyleMap.Add("weight", new PropertyValue("bold"));
            fontStyleMap.Add("width", new PropertyValue("condensed"));
            fontStyleMap.Add("slant", new PropertyValue("italic"));
            propertyMap.Add("placeholderFontStyle", new PropertyValue(fontStyleMap));

            textFieldPlaceholderTest.Size2D = new Size2D(300, 50);
            textFieldPlaceholderTest.Position2D = new Position2D(10, 230);
            textFieldPlaceholderTest.BackgroundColor = Color.Magenta;
            textFieldPlaceholderTest.Placeholder = propertyMap;
            textFieldPlaceholderTest.Focusable = true;
            window.Add(textFieldPlaceholderTest);
        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
