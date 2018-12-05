using System;
using AppNexusSDK;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

// @interface ANLocation : NSObject
[BaseType (typeof(NSObject))]
interface ANLocation
{
	// @property (assign, readwrite, nonatomic) CGFloat latitude;
	[Export ("latitude")]
	nfloat Latitude { get; set; }

	// @property (assign, readwrite, nonatomic) CGFloat longitude;
	[Export ("longitude")]
	nfloat Longitude { get; set; }

	// @property (readwrite, nonatomic, strong) NSDate * timestamp;
	[Export ("timestamp", ArgumentSemantic.Strong)]
	NSDate Timestamp { get; set; }

	// @property (assign, readwrite, nonatomic) CGFloat horizontalAccuracy;
	[Export ("horizontalAccuracy")]
	nfloat HorizontalAccuracy { get; set; }

	// @property (readonly, assign, nonatomic) NSInteger precision;
	[Export ("precision")]
	nint Precision { get; }

	// +(ANLocation *)getLocationWithLatitude:(CGFloat)latitude longitude:(CGFloat)longitude timestamp:(NSDate *)timestamp horizontalAccuracy:(CGFloat)horizontalAccuracy;
	[Static]
	[Export ("getLocationWithLatitude:longitude:timestamp:horizontalAccuracy:")]
	ANLocation GetLocationWithLatitude (nfloat latitude, nfloat longitude, NSDate timestamp, nfloat horizontalAccuracy);

	// +(ANLocation *)getLocationWithLatitude:(CGFloat)latitude longitude:(CGFloat)longitude timestamp:(NSDate *)timestamp horizontalAccuracy:(CGFloat)horizontalAccuracy precision:(NSInteger)precision;
	[Static]
	[Export ("getLocationWithLatitude:longitude:timestamp:horizontalAccuracy:precision:")]
	ANLocation GetLocationWithLatitude (nfloat latitude, nfloat longitude, NSDate timestamp, nfloat horizontalAccuracy, nint precision);
}

// @protocol ANAdProtocolFoundation <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface ANAdProtocolFoundation
{
	// @required @property (readwrite, nonatomic, strong) NSString * placementId;
	[Abstract]
	[Export ("placementId", ArgumentSemantic.Strong)]
	string PlacementId { get; set; }

	// @required @property (readonly, assign, nonatomic) NSInteger memberId;
	[Abstract]
	[Export ("memberId")]
	nint MemberId { get; }

	// @required @property (readonly, nonatomic, strong) NSString * inventoryCode;
	[Abstract]
	[Export ("inventoryCode", ArgumentSemantic.Strong)]
	string InventoryCode { get; }

	// @required @property (readwrite, nonatomic, strong) ANLocation * location;
	[Abstract]
	[Export ("location", ArgumentSemantic.Strong)]
	ANLocation Location { get; set; }

	// @required @property (assign, readwrite, nonatomic) CGFloat reserve;
	[Abstract]
	[Export ("reserve")]
	nfloat Reserve { get; set; }

	// @required @property (readwrite, nonatomic, strong) NSString * age;
	[Abstract]
	[Export ("age", ArgumentSemantic.Strong)]
	string Age { get; set; }

	// @required @property (assign, readwrite, nonatomic) ANGender gender;
	[Abstract]
	[Export ("gender", ArgumentSemantic.Assign)]
	ANGender Gender { get; set; }

	// @required @property (readwrite, nonatomic, strong) NSString * externalUid;
	[Abstract]
	[Export ("externalUid", ArgumentSemantic.Strong)]
	string ExternalUid { get; set; }

	// @required @property (readwrite, nonatomic) ANAdType adType;
	[Abstract]
	[Export ("adType", ArgumentSemantic.Assign)]
	ANAdType AdType { get; set; }

	// @required -(void)setLocationWithLatitude:(CGFloat)latitude longitude:(CGFloat)longitude timestamp:(NSDate *)timestamp horizontalAccuracy:(CGFloat)horizontalAccuracy;
	[Abstract]
	[Export ("setLocationWithLatitude:longitude:timestamp:horizontalAccuracy:")]
	void SetLocationWithLatitude (nfloat latitude, nfloat longitude, NSDate timestamp, nfloat horizontalAccuracy);

	// @required -(void)setLocationWithLatitude:(CGFloat)latitude longitude:(CGFloat)longitude timestamp:(NSDate *)timestamp horizontalAccuracy:(CGFloat)horizontalAccuracy precision:(NSInteger)precision;
	[Abstract]
	[Export ("setLocationWithLatitude:longitude:timestamp:horizontalAccuracy:precision:")]
	void SetLocationWithLatitude (nfloat latitude, nfloat longitude, NSDate timestamp, nfloat horizontalAccuracy, nint precision);

	// @required -(void)addCustomKeywordWithKey:(NSString *)key value:(NSString *)value;
	[Abstract]
	[Export ("addCustomKeywordWithKey:value:")]
	void AddCustomKeywordWithKey (string key, string value);

	// @required -(void)removeCustomKeywordWithKey:(NSString *)key;
	[Abstract]
	[Export ("removeCustomKeywordWithKey:")]
	void RemoveCustomKeywordWithKey (string key);

	// @required -(void)clearCustomKeywords;
	[Abstract]
	[Export ("clearCustomKeywords")]
	void ClearCustomKeywords ();

	// @required -(void)setInventoryCode:(NSString *)inventoryCode memberId:(NSInteger)memberID;
	[Abstract]
	[Export ("setInventoryCode:memberId:")]
	void SetInventoryCode (string inventoryCode, nint memberID);
}

// @protocol ANAdProtocolBrowser
[Protocol, Model]
interface ANAdProtocolBrowser
{
	// @required @property (readwrite, nonatomic) ANClickThroughAction clickThroughAction;
	[Abstract]
	[Export ("clickThroughAction", ArgumentSemantic.Assign)]
	ANClickThroughAction ClickThroughAction { get; set; }

	// @required @property (assign, readwrite, nonatomic) BOOL opensInNativeBrowser __attribute__((deprecated("Use enumerated type ANClickThroughAction instead.")));
	[Abstract]
	[Export ("opensInNativeBrowser")]
	bool OpensInNativeBrowser { get; set; }

	// @required @property (assign, readwrite, nonatomic) BOOL landingPageLoadsInBackground;
	[Abstract]
	[Export ("landingPageLoadsInBackground")]
	bool LandingPageLoadsInBackground { get; set; }
}

// @protocol ANAdProtocolPublicServiceAnnouncement
[Protocol, Model]
interface ANAdProtocolPublicServiceAnnouncement
{
	// @required @property (assign, readwrite, nonatomic) BOOL shouldServePublicServiceAnnouncements;
	[Abstract]
	[Export ("shouldServePublicServiceAnnouncements")]
	bool ShouldServePublicServiceAnnouncements { get; set; }
}

// @protocol ANAdProtocolVideo
[Protocol, Model]
interface ANAdProtocolVideo
{
	// @required @property (assign, readwrite, nonatomic) NSUInteger minDuration;
	[Abstract]
	[Export ("minDuration")]
	nuint MinDuration { get; set; }

	// @required @property (assign, readwrite, nonatomic) NSUInteger maxDuration;
	[Abstract]
	[Export ("maxDuration")]
	nuint MaxDuration { get; set; }
}

// @protocol ANAdProtocol <ANAdProtocolFoundation, ANAdProtocolBrowser, ANAdProtocolPublicServiceAnnouncement>
[Protocol, Model]
interface ANAdProtocol : IANAdProtocolFoundation, IANAdProtocolBrowser, IANAdProtocolPublicServiceAnnouncement
{
	// @required @property (readonly, nonatomic, strong) NSString * creativeId;
	[Abstract]
	[Export ("creativeId", ArgumentSemantic.Strong)]
	string CreativeId { get; }
}

// @protocol ANNativeAdRequestProtocol <ANAdProtocolFoundation>
[Protocol, Model]
interface ANNativeAdRequestProtocol : IANAdProtocolFoundation
{
}

// @protocol ANNativeAdResponseProtocol <ANAdProtocolBrowser>
[Protocol, Model]
interface ANNativeAdResponseProtocol : IANAdProtocolBrowser
{
}

// @protocol ANVideoAdProtocol <ANAdProtocol, ANAdProtocolVideo>
[Protocol, Model]
interface ANVideoAdProtocol : IANAdProtocol, IANAdProtocolVideo
{
}

// @protocol ANAdDelegate <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface ANAdDelegate
{
	// @optional -(void)adDidReceiveAd:(id)ad;
	[Export ("adDidReceiveAd:")]
	void AdDidReceiveAd (NSObject ad);

	// @optional -(void)ad:(id)ad requestFailedWithError:(NSError *)error;
	[Export ("ad:requestFailedWithError:")]
	void Ad (NSObject ad, NSError error);

	// @optional -(void)adWasClicked:(id)ad;
	[Export ("adWasClicked:")]
	void AdWasClicked (NSObject ad);

	// @optional -(void)adWasClicked:(id)ad withURL:(NSString *)urlString;
	[Export ("adWasClicked:withURL:")]
	void AdWasClicked (NSObject ad, string urlString);

	// @optional -(void)adWillClose:(id)ad;
	[Export ("adWillClose:")]
	void AdWillClose (NSObject ad);

	// @optional -(void)adDidClose:(id)ad;
	[Export ("adDidClose:")]
	void AdDidClose (NSObject ad);

	// @optional -(void)adWillPresent:(id)ad;
	[Export ("adWillPresent:")]
	void AdWillPresent (NSObject ad);

	// @optional -(void)adDidPresent:(id)ad;
	[Export ("adDidPresent:")]
	void AdDidPresent (NSObject ad);

	// @optional -(void)adWillLeaveApplication:(id)ad;
	[Export ("adWillLeaveApplication:")]
	void AdWillLeaveApplication (NSObject ad);
}

// @protocol ANAppEventDelegate <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface ANAppEventDelegate
{
	// @required -(void)ad:(id<ANAdProtocol>)ad didReceiveAppEvent:(NSString *)name withData:(NSString *)data;
	[Abstract]
	[Export ("ad:didReceiveAppEvent:withData:")]
	void DidReceiveAppEvent (ANAdProtocol ad, string name, string data);
}

// @interface ANAdView : UIView <ANAdProtocol>
[BaseType (typeof(UIView))]
interface ANAdView : IANAdProtocol
{
}

// @protocol ANNativeAdDelegate <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface ANNativeAdDelegate
{
	// @optional -(void)adWasClicked:(id)response;
	[Export ("adWasClicked:")]
	void AdWasClicked (NSObject response);

	// @optional -(void)adWasClicked:(id)response withURL:(NSString *)clickURLString fallbackURL:(NSString *)clickFallbackURLString;
	[Export ("adWasClicked:withURL:fallbackURL:")]
	void AdWasClicked (NSObject response, string clickURLString, string clickFallbackURLString);

	// @optional -(void)adWillPresent:(id)response;
	[Export ("adWillPresent:")]
	void AdWillPresent (NSObject response);

	// @optional -(void)adDidPresent:(id)response;
	[Export ("adDidPresent:")]
	void AdDidPresent (NSObject response);

	// @optional -(void)adWillClose:(id)response;
	[Export ("adWillClose:")]
	void AdWillClose (NSObject response);

	// @optional -(void)adDidClose:(id)response;
	[Export ("adDidClose:")]
	void AdDidClose (NSObject response);

	// @optional -(void)adWillLeaveApplication:(id)response;
	[Export ("adWillLeaveApplication:")]
	void AdWillLeaveApplication (NSObject response);
}

// @interface ANNativeAdStarRating : NSObject
[BaseType (typeof(NSObject))]
interface ANNativeAdStarRating
{
	// -(instancetype)initWithValue:(CGFloat)value scale:(NSInteger)scale;
	[Export ("initWithValue:scale:")]
	IntPtr Constructor (nfloat value, nint scale);

	// @property (readonly, assign, nonatomic) CGFloat value;
	[Export ("value")]
	nfloat Value { get; }

	// @property (readonly, assign, nonatomic) NSInteger scale;
	[Export ("scale")]
	nint Scale { get; }
}

// @interface ANNativeAdResponse : NSObject <ANNativeAdResponseProtocol>
[BaseType (typeof(NSObject))]
interface ANNativeAdResponse : IANNativeAdResponseProtocol
{
	// @property (readonly, nonatomic, strong) NSString * title;
	[Export ("title", ArgumentSemantic.Strong)]
	string Title { get; }

	// @property (readonly, nonatomic, strong) NSString * body;
	[Export ("body", ArgumentSemantic.Strong)]
	string Body { get; }

	// @property (readonly, nonatomic, strong) NSString * callToAction;
	[Export ("callToAction", ArgumentSemantic.Strong)]
	string CallToAction { get; }

	// @property (readonly, nonatomic, strong) ANNativeAdStarRating * rating;
	[Export ("rating", ArgumentSemantic.Strong)]
	ANNativeAdStarRating Rating { get; }

	// @property (readonly, nonatomic, strong) NSString * socialContext;
	[Export ("socialContext", ArgumentSemantic.Strong)]
	string SocialContext { get; }

	// @property (readonly, nonatomic, strong) UIImage * iconImage;
	[Export ("iconImage", ArgumentSemantic.Strong)]
	UIImage IconImage { get; }

	// @property (readonly, nonatomic, strong) UIImage * mainImage;
	[Export ("mainImage", ArgumentSemantic.Strong)]
	UIImage MainImage { get; }

	// @property (readonly, nonatomic, strong) NSURL * mainImageURL;
	[Export ("mainImageURL", ArgumentSemantic.Strong)]
	NSUrl MainImageURL { get; }

	// @property (readonly, assign, nonatomic) CGSize mainImageSize;
	[Export ("mainImageSize", ArgumentSemantic.Assign)]
	CGSize MainImageSize { get; }

	// @property (readonly, nonatomic, strong) NSURL * iconImageURL;
	[Export ("iconImageURL", ArgumentSemantic.Strong)]
	NSUrl IconImageURL { get; }

	// @property (readonly, nonatomic, strong) NSDictionary * customElements;
	[Export ("customElements", ArgumentSemantic.Strong)]
	NSDictionary CustomElements { get; }

	// @property (readonly, nonatomic, strong) NSString * sponsoredBy;
	[Export ("sponsoredBy", ArgumentSemantic.Strong)]
	string SponsoredBy { get; }

	// @property (readonly, nonatomic, strong) NSString * creativeId;
	[Export ("creativeId", ArgumentSemantic.Strong)]
	string CreativeId { get; }

	// @property (readonly, nonatomic, strong) NSString * fullText;
	[Export ("fullText", ArgumentSemantic.Strong)]
	string FullText { get; }

	// @property (readwrite, nonatomic, strong) NSString * additionalDescription;
	[Export ("additionalDescription", ArgumentSemantic.Strong)]
	string AdditionalDescription { get; set; }

	// @property (readonly, assign, nonatomic) ANNativeAdNetworkCode networkCode;
	[Export ("networkCode", ArgumentSemantic.Assign)]
	ANNativeAdNetworkCode NetworkCode { get; }

	// @property (readonly, getter = hasExpired, assign, nonatomic) BOOL expired;
	[Export ("expired")]
	bool Expired { [Bind ("hasExpired")] get; }

	[Wrap ("WeakDelegate")]
	ANNativeAdDelegate Delegate { get; set; }

	// @property (readwrite, nonatomic, weak) id<ANNativeAdDelegate> delegate;
	[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
	NSObject WeakDelegate { get; set; }

	// -(BOOL)registerViewForTracking:(UIView *)view withRootViewController:(UIViewController *)rvc clickableViews:(NSArray *)views error:(NSError **)error;
	[Export ("registerViewForTracking:withRootViewController:clickableViews:error:")]
	[Verify (StronglyTypedNSArray)]
	bool RegisterViewForTracking (UIView view, UIViewController rvc, NSObject[] views, out NSError error);
}

// @interface ANNativeAdRequest : NSObject <ANNativeAdRequestProtocol>
[BaseType (typeof(NSObject))]
interface ANNativeAdRequest : IANNativeAdRequestProtocol
{
	// @property (assign, readwrite, nonatomic) BOOL shouldLoadIconImage;
	[Export ("shouldLoadIconImage")]
	bool ShouldLoadIconImage { get; set; }

	// @property (assign, readwrite, nonatomic) BOOL shouldLoadMainImage;
	[Export ("shouldLoadMainImage")]
	bool ShouldLoadMainImage { get; set; }

	[Wrap ("WeakDelegate")]
	ANNativeAdRequestDelegate Delegate { get; set; }

	// @property (readwrite, nonatomic, weak) id<ANNativeAdRequestDelegate> delegate;
	[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
	NSObject WeakDelegate { get; set; }

	// -(void)loadAd;
	[Export ("loadAd")]
	void LoadAd ();
}

// @protocol ANNativeAdRequestDelegate <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface ANNativeAdRequestDelegate
{
	// @required -(void)adRequest:(ANNativeAdRequest *)request didReceiveResponse:(ANNativeAdResponse *)response;
	[Abstract]
	[Export ("adRequest:didReceiveResponse:")]
	void DidReceiveResponse (ANNativeAdRequest request, ANNativeAdResponse response);

	// @required -(void)adRequest:(ANNativeAdRequest *)request didFailToLoadWithError:(NSError *)error;
	[Abstract]
	[Export ("adRequest:didFailToLoadWithError:")]
	void DidFailToLoadWithError (ANNativeAdRequest request, NSError error);
}

// @interface ANBannerAdView : ANAdView
[BaseType (typeof(ANAdView))]
interface ANBannerAdView
{
	[Wrap ("WeakDelegate")]
	ANBannerAdViewDelegate Delegate { get; set; }

	// @property (readwrite, nonatomic, weak) id<ANBannerAdViewDelegate> delegate;
	[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
	NSObject WeakDelegate { get; set; }

	[Wrap ("WeakAppEventDelegate")]
	ANAppEventDelegate AppEventDelegate { get; set; }

	// @property (readwrite, nonatomic, weak) id<ANAppEventDelegate> appEventDelegate;
	[NullAllowed, Export ("appEventDelegate", ArgumentSemantic.Weak)]
	NSObject WeakAppEventDelegate { get; set; }

	// @property (readwrite, nonatomic, weak) UIViewController * rootViewController;
	[Export ("rootViewController", ArgumentSemantic.Weak)]
	UIViewController RootViewController { get; set; }

	// @property (assign, readwrite, nonatomic) CGSize adSize;
	[Export ("adSize", ArgumentSemantic.Assign)]
	CGSize AdSize { get; set; }

	// @property (readonly, nonatomic) CGSize loadedAdSize;
	[Export ("loadedAdSize")]
	CGSize LoadedAdSize { get; }

	// @property (readwrite, nonatomic, strong) NSArray<NSValue *> * adSizes;
	[Export ("adSizes", ArgumentSemantic.Strong)]
	NSValue[] AdSizes { get; set; }

	// @property (assign, readwrite, nonatomic) NSTimeInterval autoRefreshInterval;
	[Export ("autoRefreshInterval")]
	double AutoRefreshInterval { get; set; }

	// @property (assign, readwrite, nonatomic) ANBannerViewAdTransitionType transitionType;
	[Export ("transitionType", ArgumentSemantic.Assign)]
	ANBannerViewAdTransitionType TransitionType { get; set; }

	// @property (assign, readwrite, nonatomic) ANBannerViewAdTransitionDirection transitionDirection;
	[Export ("transitionDirection", ArgumentSemantic.Assign)]
	ANBannerViewAdTransitionDirection TransitionDirection { get; set; }

	// @property (assign, readwrite, nonatomic) NSTimeInterval transitionDuration;
	[Export ("transitionDuration")]
	double TransitionDuration { get; set; }

	// @property (assign, readwrite, nonatomic) ANBannerViewAdAlignment alignment;
	[Export ("alignment", ArgumentSemantic.Assign)]
	ANBannerViewAdAlignment Alignment { get; set; }

	// @property (assign, readwrite, nonatomic) BOOL shouldResizeAdToFitContainer;
	[Export ("shouldResizeAdToFitContainer")]
	bool ShouldResizeAdToFitContainer { get; set; }

	// @property (readwrite, nonatomic) BOOL shouldAllowVideoDemand;
	[Export ("shouldAllowVideoDemand")]
	bool ShouldAllowVideoDemand { get; set; }

	// @property (readwrite, nonatomic) BOOL shouldAllowNativeDemand;
	[Export ("shouldAllowNativeDemand")]
	bool ShouldAllowNativeDemand { get; set; }

	// -(instancetype)initWithFrame:(CGRect)frame placementId:(NSString *)placementId;
	[Export ("initWithFrame:placementId:")]
	IntPtr Constructor (CGRect frame, string placementId);

	// -(instancetype)initWithFrame:(CGRect)frame placementId:(NSString *)placementId adSize:(CGSize)size;
	[Export ("initWithFrame:placementId:adSize:")]
	IntPtr Constructor (CGRect frame, string placementId, CGSize size);

	// -(instancetype)initWithFrame:(CGRect)frame memberId:(NSInteger)memberId inventoryCode:(NSString *)inventoryCode;
	[Export ("initWithFrame:memberId:inventoryCode:")]
	IntPtr Constructor (CGRect frame, nint memberId, string inventoryCode);

	// -(instancetype)initWithFrame:(CGRect)frame memberId:(NSInteger)memberId inventoryCode:(NSString *)inventoryCode adSize:(CGSize)size;
	[Export ("initWithFrame:memberId:inventoryCode:adSize:")]
	IntPtr Constructor (CGRect frame, nint memberId, string inventoryCode, CGSize size);

	// +(ANBannerAdView *)adViewWithFrame:(CGRect)frame placementId:(NSString *)placementId;
	[Static]
	[Export ("adViewWithFrame:placementId:")]
	ANBannerAdView AdViewWithFrame (CGRect frame, string placementId);

	// +(ANBannerAdView *)adViewWithFrame:(CGRect)frame placementId:(NSString *)placementId adSize:(CGSize)size;
	[Static]
	[Export ("adViewWithFrame:placementId:adSize:")]
	ANBannerAdView AdViewWithFrame (CGRect frame, string placementId, CGSize size);

	// -(void)loadAd;
	[Export ("loadAd")]
	void LoadAd ();
}

// @protocol ANBannerAdViewDelegate <ANAdDelegate>
[Protocol, Model]
interface ANBannerAdViewDelegate : IANAdDelegate
{
}

// @interface ANTargetingParameters : NSObject
[BaseType (typeof(NSObject))]
interface ANTargetingParameters
{
	// @property (readwrite, nonatomic, strong) NSDictionary<NSString *,NSString *> * customKeywords;
	[Export ("customKeywords", ArgumentSemantic.Strong)]
	NSDictionary<NSString, NSString> CustomKeywords { get; set; }

	// @property (readwrite, nonatomic, strong) NSString * age;
	[Export ("age", ArgumentSemantic.Strong)]
	string Age { get; set; }

	// @property (assign, readwrite, nonatomic) ANGender gender;
	[Export ("gender", ArgumentSemantic.Assign)]
	ANGender Gender { get; set; }

	// @property (readwrite, nonatomic, strong) NSString * externalUid;
	[Export ("externalUid", ArgumentSemantic.Strong)]
	string ExternalUid { get; set; }

	// @property (readwrite, nonatomic, strong) ANLocation * location;
	[Export ("location", ArgumentSemantic.Strong)]
	ANLocation Location { get; set; }

	// @property (readwrite, nonatomic, strong) NSString * idforadvertising;
	[Export ("idforadvertising", ArgumentSemantic.Strong)]
	string Idforadvertising { get; set; }
}

// @protocol ANCustomAdapterDelegate <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface ANCustomAdapterDelegate
{
	// @required -(void)didFailToLoadAd:(ANAdResponseCode)errorCode;
	[Abstract]
	[Export ("didFailToLoadAd:")]
	void DidFailToLoadAd (ANAdResponseCode errorCode);

	// @required -(void)adWasClicked;
	[Abstract]
	[Export ("adWasClicked")]
	void AdWasClicked ();

	// @required -(void)willPresentAd;
	[Abstract]
	[Export ("willPresentAd")]
	void WillPresentAd ();

	// @required -(void)didPresentAd;
	[Abstract]
	[Export ("didPresentAd")]
	void DidPresentAd ();

	// @required -(void)willCloseAd;
	[Abstract]
	[Export ("willCloseAd")]
	void WillCloseAd ();

	// @required -(void)didCloseAd;
	[Abstract]
	[Export ("didCloseAd")]
	void DidCloseAd ();

	// @required -(void)willLeaveApplication;
	[Abstract]
	[Export ("willLeaveApplication")]
	void WillLeaveApplication ();
}

// @protocol ANCustomAdapter <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface ANCustomAdapter
{
	[Wrap ("WeakDelegate"), Abstract]
	ANCustomAdapterDelegate Delegate { get; set; }

	// @required @property (readwrite, nonatomic, weak) id<ANCustomAdapterDelegate> delegate;
	[Abstract]
	[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
	NSObject WeakDelegate { get; set; }
}

// @protocol ANCustomAdapterBanner <ANCustomAdapter>
[Protocol, Model]
interface ANCustomAdapterBanner : IANCustomAdapter
{
	// @required -(void)requestBannerAdWithSize:(CGSize)size rootViewController:(UIViewController *)rootViewController serverParameter:(NSString *)parameterString adUnitId:(NSString *)idString targetingParameters:(ANTargetingParameters *)targetingParameters;
	[Abstract]
	[Export ("requestBannerAdWithSize:rootViewController:serverParameter:adUnitId:targetingParameters:")]
	void RootViewController (CGSize size, UIViewController rootViewController, string parameterString, string idString, ANTargetingParameters targetingParameters);

	[Wrap ("WeakDelegate"), Abstract]
	NSObject<ANCustomAdapterBannerDelegate, ANCustomAdapterDelegate> Delegate { get; set; }

	// @required @property (readwrite, nonatomic, weak) id<ANCustomAdapterBannerDelegate,ANCustomAdapterDelegate> delegate;
	[Abstract]
	[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
	NSObject WeakDelegate { get; set; }
}

// @protocol ANCustomAdapterInterstitial <ANCustomAdapter>
[Protocol, Model]
interface ANCustomAdapterInterstitial : IANCustomAdapter
{
	// @required -(void)requestInterstitialAdWithParameter:(NSString *)parameterString adUnitId:(NSString *)idString targetingParameters:(ANTargetingParameters *)targetingParameters;
	[Abstract]
	[Export ("requestInterstitialAdWithParameter:adUnitId:targetingParameters:")]
	void RequestInterstitialAdWithParameter (string parameterString, string idString, ANTargetingParameters targetingParameters);

	// @required -(void)presentFromViewController:(UIViewController *)viewController;
	[Abstract]
	[Export ("presentFromViewController:")]
	void PresentFromViewController (UIViewController viewController);

	// @required -(BOOL)isReady;
	[Abstract]
	[Export ("isReady")]
	[Verify (MethodToProperty)]
	bool IsReady { get; }

	[Wrap ("WeakDelegate"), Abstract]
	NSObject<ANCustomAdapterInterstitialDelegate, ANCustomAdapterDelegate> Delegate { get; set; }

	// @required @property (readwrite, nonatomic, weak) id<ANCustomAdapterInterstitialDelegate,ANCustomAdapterDelegate> delegate;
	[Abstract]
	[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
	NSObject WeakDelegate { get; set; }
}

// @protocol ANCustomAdapterBannerDelegate <ANCustomAdapterDelegate>
[Protocol, Model]
interface ANCustomAdapterBannerDelegate : IANCustomAdapterDelegate
{
	// @required -(void)didLoadBannerAd:(UIView *)view;
	[Abstract]
	[Export ("didLoadBannerAd:")]
	void DidLoadBannerAd (UIView view);
}

// @protocol ANCustomAdapterInterstitialDelegate <ANCustomAdapterDelegate>
[Protocol, Model]
interface ANCustomAdapterInterstitialDelegate : IANCustomAdapterDelegate
{
	// @required -(void)didLoadInterstitialAd:(id<ANCustomAdapterInterstitial>)adapter;
	[Abstract]
	[Export ("didLoadInterstitialAd:")]
	void DidLoadInterstitialAd (ANCustomAdapterInterstitial adapter);

	// @required -(void)failedToDisplayAd;
	[Abstract]
	[Export ("failedToDisplayAd")]
	void FailedToDisplayAd ();
}

// @interface ANGDPRSettings : NSObject
[BaseType (typeof(NSObject))]
interface ANGDPRSettings
{
	// +(void)setConsentString:(NSString *)consentString;
	[Static]
	[Export ("setConsentString:")]
	void SetConsentString (string consentString);

	// +(void)setConsentRequired:(BOOL)consentRequired;
	[Static]
	[Export ("setConsentRequired:")]
	void SetConsentRequired (bool consentRequired);

	// +(NSString *)getConsentString;
	[Static]
	[Export ("getConsentString")]
	[Verify (MethodToProperty)]
	string ConsentString { get; }

	// +(NSString *)getConsentRequired;
	[Static]
	[Export ("getConsentRequired")]
	[Verify (MethodToProperty)]
	string ConsentRequired { get; }

	// +(void)reset;
	[Static]
	[Export ("reset")]
	void Reset ();
}

// @protocol ANInstreamVideoAdLoadDelegate <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface ANInstreamVideoAdLoadDelegate
{
	// @required -(void)adDidReceiveAd:(id<ANAdProtocol>)ad;
	[Abstract]
	[Export ("adDidReceiveAd:")]
	void AdDidReceiveAd (ANAdProtocol ad);

	// @optional -(void)ad:(id<ANAdProtocol>)ad requestFailedWithError:(NSError *)error;
	[Export ("ad:requestFailedWithError:")]
	void Ad (ANAdProtocol ad, NSError error);
}

// @protocol ANInstreamVideoAdPlayDelegate <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface ANInstreamVideoAdPlayDelegate
{
	// @required -(void)adDidComplete:(id<ANAdProtocol>)ad withState:(ANInstreamVideoPlaybackStateType)state;
	[Abstract]
	[Export ("adDidComplete:withState:")]
	void AdDidComplete (ANAdProtocol ad, ANInstreamVideoPlaybackStateType state);

	// @optional -(void)adCompletedFirstQuartile:(id<ANAdProtocol>)ad;
	[Export ("adCompletedFirstQuartile:")]
	void AdCompletedFirstQuartile (ANAdProtocol ad);

	// @optional -(void)adCompletedMidQuartile:(id<ANAdProtocol>)ad;
	[Export ("adCompletedMidQuartile:")]
	void AdCompletedMidQuartile (ANAdProtocol ad);

	// @optional -(void)adCompletedThirdQuartile:(id<ANAdProtocol>)ad;
	[Export ("adCompletedThirdQuartile:")]
	void AdCompletedThirdQuartile (ANAdProtocol ad);

	// @optional -(void)adMute:(id<ANAdProtocol>)ad withStatus:(BOOL)muteStatus;
	[Export ("adMute:withStatus:")]
	void AdMute (ANAdProtocol ad, bool muteStatus);

	// @optional -(void)adWasClicked:(id<ANAdProtocol>)ad;
	[Export ("adWasClicked:")]
	void AdWasClicked (ANAdProtocol ad);

	// @optional -(void)adWasClicked:(id<ANAdProtocol>)ad withURL:(NSString *)urlString;
	[Export ("adWasClicked:withURL:")]
	void AdWasClicked (ANAdProtocol ad, string urlString);

	// @optional -(void)adWillClose:(id<ANAdProtocol>)ad;
	[Export ("adWillClose:")]
	void AdWillClose (ANAdProtocol ad);

	// @optional -(void)adDidClose:(id<ANAdProtocol>)ad;
	[Export ("adDidClose:")]
	void AdDidClose (ANAdProtocol ad);

	// @optional -(void)adWillPresent:(id<ANAdProtocol>)ad;
	[Export ("adWillPresent:")]
	void AdWillPresent (ANAdProtocol ad);

	// @optional -(void)adDidPresent:(id<ANAdProtocol>)ad;
	[Export ("adDidPresent:")]
	void AdDidPresent (ANAdProtocol ad);

	// @optional -(void)adWillLeaveApplication:(id<ANAdProtocol>)ad;
	[Export ("adWillLeaveApplication:")]
	void AdWillLeaveApplication (ANAdProtocol ad);

	// @optional -(void)adPlayStarted:(id<ANAdProtocol>)ad;
	[Export ("adPlayStarted:")]
	void AdPlayStarted (ANAdProtocol ad);
}

// @interface ANInstreamVideoAd : ANAdView <ANVideoAdProtocol>
[BaseType (typeof(ANAdView))]
interface ANInstreamVideoAd : IANVideoAdProtocol
{
	[Wrap ("WeakLoadDelegate")]
	ANInstreamVideoAdLoadDelegate LoadDelegate { get; }

	// @property (readonly, nonatomic, weak) id<ANInstreamVideoAdLoadDelegate> loadDelegate;
	[NullAllowed, Export ("loadDelegate", ArgumentSemantic.Weak)]
	NSObject WeakLoadDelegate { get; }

	[Wrap ("WeakPlayDelegate")]
	ANInstreamVideoAdPlayDelegate PlayDelegate { get; }

	// @property (readonly, nonatomic, weak) id<ANInstreamVideoAdPlayDelegate> playDelegate;
	[NullAllowed, Export ("playDelegate", ArgumentSemantic.Weak)]
	NSObject WeakPlayDelegate { get; }

	// @property (readonly, nonatomic, strong) NSString * descriptionOfFailure;
	[Export ("descriptionOfFailure", ArgumentSemantic.Strong)]
	string DescriptionOfFailure { get; }

	// @property (readonly, nonatomic, strong) NSError * failureNSError;
	[Export ("failureNSError", ArgumentSemantic.Strong)]
	NSError FailureNSError { get; }

	// @property (readonly, nonatomic) BOOL didUserSkipAd;
	[Export ("didUserSkipAd")]
	bool DidUserSkipAd { get; }

	// @property (readonly, nonatomic) BOOL didUserClickAd;
	[Export ("didUserClickAd")]
	bool DidUserClickAd { get; }

	// @property (readonly, nonatomic) BOOL isAdMuted;
	[Export ("isAdMuted")]
	bool IsAdMuted { get; }

	// @property (readonly, nonatomic) BOOL isVideoTagReady;
	[Export ("isVideoTagReady")]
	bool IsVideoTagReady { get; }

	// @property (readonly, nonatomic) BOOL didVideoTagFail;
	[Export ("didVideoTagFail")]
	bool DidVideoTagFail { get; }

	// -(instancetype)initWithPlacementId:(NSString *)placementId;
	[Export ("initWithPlacementId:")]
	IntPtr Constructor (string placementId);

	// -(instancetype)initWithMemberId:(NSInteger)memberId inventoryCode:(NSString *)inventoryCode;
	[Export ("initWithMemberId:inventoryCode:")]
	IntPtr Constructor (nint memberId, string inventoryCode);

	// -(BOOL)loadAdWithDelegate:(id<ANInstreamVideoAdLoadDelegate>)loadDelegate;
	[Export ("loadAdWithDelegate:")]
	bool LoadAdWithDelegate (ANInstreamVideoAdLoadDelegate loadDelegate);

	// -(void)playAdWithContainer:(UIView *)adContainer withDelegate:(id<ANInstreamVideoAdPlayDelegate>)playDelegate;
	[Export ("playAdWithContainer:withDelegate:")]
	void PlayAdWithContainer (UIView adContainer, ANInstreamVideoAdPlayDelegate playDelegate);

	// -(void)removeAd;
	[Export ("removeAd")]
	void RemoveAd ();

	// -(NSUInteger)getAdDuration;
	[Export ("getAdDuration")]
	[Verify (MethodToProperty)]
	nuint AdDuration { get; }

	// -(NSString *)getCreativeURL;
	[Export ("getCreativeURL")]
	[Verify (MethodToProperty)]
	string CreativeURL { get; }

	// -(NSString *)getVastURL;
	[Export ("getVastURL")]
	[Verify (MethodToProperty)]
	string VastURL { get; }

	// -(NSString *)getVastXML;
	[Export ("getVastXML")]
	[Verify (MethodToProperty)]
	string VastXML { get; }

	// -(NSUInteger)getAdPlayElapsedTime;
	[Export ("getAdPlayElapsedTime")]
	[Verify (MethodToProperty)]
	nuint AdPlayElapsedTime { get; }
}

// @interface ANInterstitialAd : ANAdView
[BaseType (typeof(ANAdView))]
interface ANInterstitialAd
{
	[Wrap ("WeakDelegate")]
	ANInterstitialAdDelegate Delegate { get; set; }

	// @property (readwrite, nonatomic, weak) id<ANInterstitialAdDelegate> delegate;
	[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
	NSObject WeakDelegate { get; set; }

	[Wrap ("WeakAppEventDelegate")]
	ANAppEventDelegate AppEventDelegate { get; set; }

	// @property (readwrite, nonatomic, weak) id<ANAppEventDelegate> appEventDelegate;
	[NullAllowed, Export ("appEventDelegate", ArgumentSemantic.Weak)]
	NSObject WeakAppEventDelegate { get; set; }

	// @property (readwrite, nonatomic, strong) UIColor * backgroundColor;
	[Export ("backgroundColor", ArgumentSemantic.Strong)]
	UIColor BackgroundColor { get; set; }

	// @property (getter = isOpaque, readwrite, nonatomic) BOOL opaque;
	[Export ("opaque")]
	bool Opaque { [Bind ("isOpaque")] get; set; }

	// @property (readonly, assign, nonatomic) BOOL isReady;
	[Export ("isReady")]
	bool IsReady { get; }

	// @property (assign, readwrite, nonatomic) NSTimeInterval closeDelay;
	[Export ("closeDelay")]
	double CloseDelay { get; set; }

	// @property (readwrite, nonatomic, strong) NSMutableSet<NSValue *> * allowedAdSizes;
	[Export ("allowedAdSizes", ArgumentSemantic.Strong)]
	NSMutableSet<NSValue> AllowedAdSizes { get; set; }

	// @property (assign, readwrite, nonatomic) BOOL dismissOnClick;
	[Export ("dismissOnClick")]
	bool DismissOnClick { get; set; }

	// -(instancetype)initWithPlacementId:(NSString *)placementId;
	[Export ("initWithPlacementId:")]
	IntPtr Constructor (string placementId);

	// -(instancetype)initWithMemberId:(NSInteger)memberId inventoryCode:(NSString *)inventoryCode;
	[Export ("initWithMemberId:inventoryCode:")]
	IntPtr Constructor (nint memberId, string inventoryCode);

	// -(void)loadAd;
	[Export ("loadAd")]
	void LoadAd ();

	// -(void)displayAdFromViewController:(UIViewController *)controller;
	[Export ("displayAdFromViewController:")]
	void DisplayAdFromViewController (UIViewController controller);

	// -(void)displayAdFromViewController:(UIViewController *)controller autoDismissDelay:(NSTimeInterval)delay;
	[Export ("displayAdFromViewController:autoDismissDelay:")]
	void DisplayAdFromViewController (UIViewController controller, double delay);
}

// @protocol ANInterstitialAdDelegate <ANAdDelegate>
[Protocol, Model]
interface ANInterstitialAdDelegate : IANAdDelegate
{
	// @optional -(void)adFailedToDisplay:(ANInterstitialAd *)ad;
	[Export ("adFailedToDisplay:")]
	void AdFailedToDisplay (ANInterstitialAd ad);
}

// @interface ANLogManager : NSObject
[BaseType (typeof(NSObject))]
interface ANLogManager
{
	// +(ANLogLevel)getANLogLevel;
	[Static]
	[Export ("getANLogLevel")]
	[Verify (MethodToProperty)]
	ANLogLevel ANLogLevel { get; }

	// +(void)setANLogLevel:(ANLogLevel)level;
	[Static]
	[Export ("setANLogLevel:")]
	void SetANLogLevel (ANLogLevel level);
}

// @interface ANSDKSettings : NSObject
[BaseType (typeof(NSObject))]
interface ANSDKSettings
{
	// @property (nonatomic) BOOL HTTPSEnabled;
	[Export ("HTTPSEnabled")]
	bool HTTPSEnabled { get; set; }

	// @property (copy, nonatomic) NSArray<NSValue *> * sizesThatShouldConstrainToSuperview;
	[Export ("sizesThatShouldConstrainToSuperview", ArgumentSemantic.Copy)]
	NSValue[] SizesThatShouldConstrainToSuperview { get; set; }

	// @property (nonatomic) BOOL locationEnabledForCreative;
	[Export ("locationEnabledForCreative")]
	bool LocationEnabledForCreative { get; set; }

	// +(instancetype)sharedInstance;
	[Static]
	[Export ("sharedInstance")]
	ANSDKSettings SharedInstance ();

	// -(void)optionalSDKInitialization;
	[Export ("optionalSDKInitialization")]
	void OptionalSDKInitialization ();
}

// @interface ANNativeMediatedAdResponse : ANNativeAdResponse
[BaseType (typeof(ANNativeAdResponse))]
interface ANNativeMediatedAdResponse
{
	// -(instancetype)initWithCustomAdapter:(id<ANNativeCustomAdapter>)adapter networkCode:(ANNativeAdNetworkCode)networkCode;
	[Export ("initWithCustomAdapter:networkCode:")]
	IntPtr Constructor (ANNativeCustomAdapter adapter, ANNativeAdNetworkCode networkCode);

	// @property (readwrite, nonatomic, strong) NSString * title;
	[Export ("title", ArgumentSemantic.Strong)]
	string Title { get; set; }

	// @property (readwrite, nonatomic, strong) NSString * body;
	[Export ("body", ArgumentSemantic.Strong)]
	string Body { get; set; }

	// @property (readwrite, nonatomic, strong) NSString * callToAction;
	[Export ("callToAction", ArgumentSemantic.Strong)]
	string CallToAction { get; set; }

	// @property (readwrite, nonatomic, strong) ANNativeAdStarRating * rating;
	[Export ("rating", ArgumentSemantic.Strong)]
	ANNativeAdStarRating Rating { get; set; }

	// @property (readwrite, nonatomic, strong) UIImage * mainImage;
	[Export ("mainImage", ArgumentSemantic.Strong)]
	UIImage MainImage { get; set; }

	// @property (readwrite, nonatomic, strong) NSURL * mainImageURL;
	[Export ("mainImageURL", ArgumentSemantic.Strong)]
	NSUrl MainImageURL { get; set; }

	// @property (readwrite, nonatomic, strong) UIImage * iconImage;
	[Export ("iconImage", ArgumentSemantic.Strong)]
	UIImage IconImage { get; set; }

	// @property (readwrite, nonatomic, strong) NSURL * iconImageURL;
	[Export ("iconImageURL", ArgumentSemantic.Strong)]
	NSUrl IconImageURL { get; set; }

	// @property (readwrite, nonatomic, strong) NSString * socialContext;
	[Export ("socialContext", ArgumentSemantic.Strong)]
	string SocialContext { get; set; }

	// @property (readwrite, nonatomic, strong) NSDictionary * customElements;
	[Export ("customElements", ArgumentSemantic.Strong)]
	NSDictionary CustomElements { get; set; }

	// @property (readonly, nonatomic, strong) id<ANNativeCustomAdapter> adapter;
	[Export ("adapter", ArgumentSemantic.Strong)]
	ANNativeCustomAdapter Adapter { get; }
}

// @protocol ANNativeCustomAdapter <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface ANNativeCustomAdapter
{
	[Wrap ("WeakRequestDelegate"), Abstract]
	ANNativeCustomAdapterRequestDelegate RequestDelegate { get; set; }

	// @required @property (readwrite, nonatomic, weak) id<ANNativeCustomAdapterRequestDelegate> requestDelegate;
	[Abstract]
	[NullAllowed, Export ("requestDelegate", ArgumentSemantic.Weak)]
	NSObject WeakRequestDelegate { get; set; }

	[Wrap ("WeakNativeAdDelegate"), Abstract]
	ANNativeCustomAdapterAdDelegate NativeAdDelegate { get; set; }

	// @required @property (readwrite, nonatomic, weak) id<ANNativeCustomAdapterAdDelegate> nativeAdDelegate;
	[Abstract]
	[NullAllowed, Export ("nativeAdDelegate", ArgumentSemantic.Weak)]
	NSObject WeakNativeAdDelegate { get; set; }

	// @required @property (getter = hasExpired, assign, readwrite, nonatomic) BOOL expired;
	[Abstract]
	[Export ("expired")]
	bool Expired { [Bind ("hasExpired")] get; set; }

	// @required -(void)requestNativeAdWithServerParameter:(NSString *)parameterString adUnitId:(NSString *)adUnitId targetingParameters:(ANTargetingParameters *)targetingParameters;
	[Abstract]
	[Export ("requestNativeAdWithServerParameter:adUnitId:targetingParameters:")]
	void RequestNativeAdWithServerParameter (string parameterString, string adUnitId, ANTargetingParameters targetingParameters);

	// @optional -(void)registerViewForImpressionTrackingAndClickHandling:(UIView *)view withRootViewController:(UIViewController *)rvc clickableViews:(NSArray *)clickableViews;
	[Export ("registerViewForImpressionTrackingAndClickHandling:withRootViewController:clickableViews:")]
	[Verify (StronglyTypedNSArray)]
	void RegisterViewForImpressionTrackingAndClickHandling (UIView view, UIViewController rvc, NSObject[] clickableViews);

	// @optional -(void)registerViewForImpressionTracking:(UIView *)view;
	[Export ("registerViewForImpressionTracking:")]
	void RegisterViewForImpressionTracking (UIView view);

	// @optional -(void)handleClickFromRootViewController:(UIViewController *)rvc;
	[Export ("handleClickFromRootViewController:")]
	void HandleClickFromRootViewController (UIViewController rvc);

	// @optional -(void)unregisterViewFromTracking;
	[Export ("unregisterViewFromTracking")]
	void UnregisterViewFromTracking ();
}

// @protocol ANNativeCustomAdapterRequestDelegate <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface ANNativeCustomAdapterRequestDelegate
{
	// @required -(void)didLoadNativeAd:(ANNativeMediatedAdResponse *)response;
	[Abstract]
	[Export ("didLoadNativeAd:")]
	void DidLoadNativeAd (ANNativeMediatedAdResponse response);

	// @required -(void)didFailToLoadNativeAd:(ANAdResponseCode)errorCode;
	[Abstract]
	[Export ("didFailToLoadNativeAd:")]
	void DidFailToLoadNativeAd (ANAdResponseCode errorCode);
}

// @protocol ANNativeCustomAdapterAdDelegate <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface ANNativeCustomAdapterAdDelegate
{
	// @optional -(void)didInteractWithParams;
	[Export ("didInteractWithParams")]
	void DidInteractWithParams ();

	// @required -(void)adWasClicked;
	[Abstract]
	[Export ("adWasClicked")]
	void AdWasClicked ();

	// @required -(void)willPresentAd;
	[Abstract]
	[Export ("willPresentAd")]
	void WillPresentAd ();

	// @required -(void)didPresentAd;
	[Abstract]
	[Export ("didPresentAd")]
	void DidPresentAd ();

	// @required -(void)willCloseAd;
	[Abstract]
	[Export ("willCloseAd")]
	void WillCloseAd ();

	// @required -(void)didCloseAd;
	[Abstract]
	[Export ("didCloseAd")]
	void DidCloseAd ();

	// @required -(void)willLeaveApplication;
	[Abstract]
	[Export ("willLeaveApplication")]
	void WillLeaveApplication ();

	// @required -(void)adDidLogImpression;
	[Abstract]
	[Export ("adDidLogImpression")]
	void AdDidLogImpression ();
}

[Static]
[Verify (ConstantsInterfaceAssociation)]
partial interface Constants
{
	// extern double AppNexusSDKVersionNumber;
	[Field ("AppNexusSDKVersionNumber", "__Internal")]
	double AppNexusSDKVersionNumber { get; }

	// extern const unsigned char [] AppNexusSDKVersionString;
	[Field ("AppNexusSDKVersionString", "__Internal")]
	byte[] AppNexusSDKVersionString { get; }
}
