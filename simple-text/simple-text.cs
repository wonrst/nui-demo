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
using System.Globalization;

namespace HelloWorldTest
{
    class Example : NUIApplication
    {
        private Animation _animation;
        private TextLabel _text;
        private int cnt;
        private View _view;
        TextField textFieldPlaceholderTest;
        TextLabel keySubclassTest;

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }
        public void Initialize()
        {
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;

            myTextLabel = new TextLabel("get date");
            myTextLabel.Position2D = new Position2D(10, 70);
            myTextLabel.PointSize = 20.0f;
            window.Add(myTextLabel);

            myTextLabel.Text = GetDate();

            for (int i = 1 ; i < 20 ; i ++)
            {
                myTextLabel = new TextLabel("get date");
                myTextLabel.Position2D = new Position2D(10, 70 + (i*30));
                myTextLabel.PointSize = 20.0f;
                window.Add(myTextLabel);
                myTextLabel.Text = GetDate();
            }

            for (int i = 0 ; i < 20 ; i ++)
            {
                myTextLabel = new TextLabel("get date");
                myTextLabel.Position2D = new Position2D(250, 70 + (i*30));
                myTextLabel.PointSize = 20.0f;
                window.Add(myTextLabel);
                myTextLabel.Text = GetDate();
            }
        }

        private string GetDate()
        {
            DateTime date = DateTime.Now.Date;
            //return date.ToString(" MMM ").ToUpper() + date.ToString("d일 dddd");
            //return date.ToLongDateString();

            return "\U0001f601";
            //return "\ud83d\ude01";
            
        }


        private TextLabel myTextLabel;

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
