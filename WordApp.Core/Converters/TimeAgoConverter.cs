// The MIT License (MIT)
//
// Copyright (c) 2015 FPT Software
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using Cirrious.CrossCore.Converters;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Localization;

namespace Cirrious.Conference.Core.Converters
{
    public class TimeAgoValueConverter
        : MvxValueConverter
          
    {


        public override object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
			var when = DateTime.Parse((string)value);//(DateTime)value;

			string retVal;
			if (when == DateTime.MinValue)
			{
				retVal = "Just Now";
			}
			else
			{
			    var whenUtc = when.ToUniversalTime();
                var difference = (DateTime.UtcNow - whenUtc).TotalSeconds;
				if (difference < 100.0) {
					retVal = "Just Now";
				} else if (difference < 3600.0) {
					retVal = (int)(difference / 60) + " minutes ago";
				} else if (difference < 24 * 3600) {
					int tmp = (int)(difference / 3600);
					if (tmp == 1)
						retVal = tmp + "h ago";
					else
						retVal = tmp + "h ago";
				} else if (difference < 24 * 3600 * 30) {
					int tmp = (int)(difference / (3600 * 24));
					if (tmp == 1)
						retVal = "1 day ago";
					else
						retVal = tmp + " days ago";
				} else if (difference < 24 * 3600 * 30 * 12) {
					int tmp = (int)(difference / (3600 * 24 * 30));
					if (tmp == 1)
						retVal = "1 month ago";
					else
						retVal = tmp + " months ago";
				} else {
					int tmp = (int)(difference / (3600 * 24 * 30 * 12));
					if (tmp == 1)
						retVal = "1 year ago";
					else
						retVal = tmp + " years ago";
				}
			}
			return retVal;
        }
    }
}
