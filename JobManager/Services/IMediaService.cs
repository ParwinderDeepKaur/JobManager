﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JobManager.Services
{
    public interface IMediaService
    {
        Task<Image> CapturePhotoAsync();
    }
}