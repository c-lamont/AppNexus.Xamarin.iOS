﻿using System;
using ObjCRuntime;

namespace AppNexus.Xamarin.iOS
{
    [Native]
    public enum ANAdResponseCode : long
    {
        DefaultCode = -1,
        AdResponseSuccessful = 0,
        AdResponseInvalidRequest,
        AdResponseUnableToFill,
        AdResponseMediatedSDKUnavailable,
        AdResponseNetworkError,
        AdResponseInternalError,
        AdResponseBadFormat = 100,
        AdResponseBadURL,
        AdResponseBadURLConnection,
        AdResponseNonViewResponse
    }

    [Native]
    public enum ANGender : long
    {
        Unknown,
        Male,
        Female
    }

    [Native]
    public enum ANNativeAdRegisterErrorCode : long
    {
        InvalidView = 200,
        InvalidRootViewController,
        ExpiredResponse,
        BadAdapter,
        InternalError
    }

    [Native]
    public enum ANNativeAdNetworkCode : long
    {
        AppNexus = 0,
        Facebook,
        InMobi,
        Yahoo,
        Custom,
        AdMob
    }

    [Native]
    public enum ANAdType : long
    {
        Unknown = 0,
        Banner = 1,
        Video = 2,
        Native = 3
    }

    [Native]
    public enum ANClickThroughAction : long
    {
        ReturnURL,
        OpenDeviceBrowser,
        OpenSDKBrowser
    }

    [Native]
    public enum ANBannerViewAdTransitionType : long
    {
        None = 0,
        Fade,
        Push,
        MoveIn,
        Reveal,
        Flip
    }

    [Native]
    public enum ANBannerViewAdTransitionDirection : long
    {
        Up = 0,
        Down,
        Left,
        Right,
        Random
    }

    [Native]
    public enum ANBannerViewAdAlignment : long
    {
        Center = 0,
        TopLeft,
        TopCenter,
        TopRight,
        CenterLeft,
        CenterRight,
        BottomLeft,
        BottomCenter,
        BottomRight
    }

    [Native]
    public enum ANInstreamVideoPlaybackStateType : long
    {
        Error = -1,
        Completed = 0,
        Skipped = 1
    }

    [Native]
    public enum ANLogLevel : long
    {
        All = 0,
        Mark = 9,
        Trace = 10,
        Debug = 20,
        Info = 30,
        Warn = 40,
        Error = 50,
        Off = 60
    }
}
