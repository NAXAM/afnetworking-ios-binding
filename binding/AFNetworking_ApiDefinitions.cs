using System;
using AFNetworking;
using CoreFoundation;
using Foundation;
using ObjCRuntime;
using Security;
using SystemConfiguration;
using UIKit;

namespace AFNetworkingLib
{
	// @protocol AFURLRequestSerialization <NSObject, NSSecureCoding, NSCopying>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface AFURLRequestSerialization : INSSecureCoding, INSCopying
	{
		// @required -(NSURLRequest * _Nullable)requestBySerializingRequest:(NSURLRequest * _Nonnull)request withParameters:(id _Nullable)parameters error:(NSError * _Nullable * _Nullable)error;
		[Abstract]
		[Export ("requestBySerializingRequest:withParameters:error:")]
		[return: NullAllowed]
		NSUrlRequest WithParameters (NSUrlRequest request, [NullAllowed] NSObject parameters, [NullAllowed] out NSError error);
	}

	// @interface AFHTTPRequestSerializer : NSObject <AFURLRequestSerialization>
	[BaseType (typeof(NSObject))]
	interface AFHTTPRequestSerializer : IAFURLRequestSerialization
	{
		// @property (assign, nonatomic) NSStringEncoding stringEncoding;
		[Export ("stringEncoding")]
		nuint StringEncoding { get; set; }

		// @property (assign, nonatomic) BOOL allowsCellularAccess;
		[Export ("allowsCellularAccess")]
		bool AllowsCellularAccess { get; set; }

		// @property (assign, nonatomic) NSURLRequestCachePolicy cachePolicy;
		[Export ("cachePolicy", ArgumentSemantic.Assign)]
		NSURLRequestCachePolicy CachePolicy { get; set; }

		// @property (assign, nonatomic) BOOL HTTPShouldHandleCookies;
		[Export ("HTTPShouldHandleCookies")]
		bool HTTPShouldHandleCookies { get; set; }

		// @property (assign, nonatomic) BOOL HTTPShouldUsePipelining;
		[Export ("HTTPShouldUsePipelining")]
		bool HTTPShouldUsePipelining { get; set; }

		// @property (assign, nonatomic) NSURLRequestNetworkServiceType networkServiceType;
		[Export ("networkServiceType", ArgumentSemantic.Assign)]
		NSURLRequestNetworkServiceType NetworkServiceType { get; set; }

		// @property (assign, nonatomic) NSTimeInterval timeoutInterval;
		[Export ("timeoutInterval")]
		double TimeoutInterval { get; set; }

		// @property (readonly, nonatomic, strong) NSDictionary<NSString *,NSString *> * _Nonnull HTTPRequestHeaders;
		[Export ("HTTPRequestHeaders", ArgumentSemantic.Strong)]
		NSDictionary<NSString, NSString> HTTPRequestHeaders { get; }

		// +(instancetype _Nonnull)serializer;
		[Static]
		[Export ("serializer")]
		AFHTTPRequestSerializer Serializer ();

		// -(void)setValue:(NSString * _Nullable)value forHTTPHeaderField:(NSString * _Nonnull)field;
		[Export ("setValue:forHTTPHeaderField:")]
		void SetValue ([NullAllowed] string value, string field);

		// -(NSString * _Nullable)valueForHTTPHeaderField:(NSString * _Nonnull)field;
		[Export ("valueForHTTPHeaderField:")]
		[return: NullAllowed]
		string ValueForHTTPHeaderField (string field);

		// -(void)setAuthorizationHeaderFieldWithUsername:(NSString * _Nonnull)username password:(NSString * _Nonnull)password;
		[Export ("setAuthorizationHeaderFieldWithUsername:password:")]
		void SetAuthorizationHeaderFieldWithUsername (string username, string password);

		// -(void)clearAuthorizationHeader;
		[Export ("clearAuthorizationHeader")]
		void ClearAuthorizationHeader ();

		// @property (nonatomic, strong) NSSet<NSString *> * _Nonnull HTTPMethodsEncodingParametersInURI;
		[Export ("HTTPMethodsEncodingParametersInURI", ArgumentSemantic.Strong)]
		NSSet<NSString> HTTPMethodsEncodingParametersInURI { get; set; }

		// -(void)setQueryStringSerializationWithStyle:(AFHTTPRequestQueryStringSerializationStyle)style;
		[Export ("setQueryStringSerializationWithStyle:")]
		void SetQueryStringSerializationWithStyle (AFHTTPRequestQueryStringSerializationStyle style);

		// -(void)setQueryStringSerializationWithBlock:(NSString * _Nonnull (^ _Nullable)(NSURLRequest * _Nonnull, id _Nonnull, NSError * _Nullable * _Nullable))block;
		[Export ("setQueryStringSerializationWithBlock:")]
		unsafe void SetQueryStringSerializationWithBlock ([NullAllowed] Func<NSURLRequest, NSObject, Foundation.NSError*, NSString> block);

		// -(NSMutableURLRequest * _Nonnull)requestWithMethod:(NSString * _Nonnull)method URLString:(NSString * _Nonnull)URLString parameters:(id _Nullable)parameters error:(NSError * _Nullable * _Nullable)error;
		[Export ("requestWithMethod:URLString:parameters:error:")]
		NSMutableUrlRequest RequestWithMethod (string method, string URLString, [NullAllowed] NSObject parameters, [NullAllowed] out NSError error);

		// -(NSMutableURLRequest * _Nonnull)multipartFormRequestWithMethod:(NSString * _Nonnull)method URLString:(NSString * _Nonnull)URLString parameters:(NSDictionary<NSString *,id> * _Nullable)parameters constructingBodyWithBlock:(void (^ _Nullable)(id<AFMultipartFormData> _Nonnull))block error:(NSError * _Nullable * _Nullable)error;
		[Export ("multipartFormRequestWithMethod:URLString:parameters:constructingBodyWithBlock:error:")]
		NSMutableUrlRequest MultipartFormRequestWithMethod (string method, string URLString, [NullAllowed] NSDictionary<NSString, NSObject> parameters, [NullAllowed] Action<AFMultipartFormData> block, [NullAllowed] out NSError error);

		// -(NSMutableURLRequest * _Nonnull)requestWithMultipartFormRequest:(NSURLRequest * _Nonnull)request writingStreamContentsToFile:(NSURL * _Nonnull)fileURL completionHandler:(void (^ _Nullable)(NSError * _Nullable))handler;
		[Export ("requestWithMultipartFormRequest:writingStreamContentsToFile:completionHandler:")]
		NSMutableUrlRequest RequestWithMultipartFormRequest (NSUrlRequest request, NSUrl fileURL, [NullAllowed] Action<NSError> handler);
	}

	// @protocol AFMultipartFormData
	[Protocol, Model]
	interface AFMultipartFormData
	{
		// @required -(BOOL)appendPartWithFileURL:(NSURL * _Nonnull)fileURL name:(NSString * _Nonnull)name error:(NSError * _Nullable * _Nullable)error;
		[Abstract]
		[Export ("appendPartWithFileURL:name:error:")]
		bool AppendPartWithFileURL (NSUrl fileURL, string name, [NullAllowed] out NSError error);

		// @required -(BOOL)appendPartWithFileURL:(NSURL * _Nonnull)fileURL name:(NSString * _Nonnull)name fileName:(NSString * _Nonnull)fileName mimeType:(NSString * _Nonnull)mimeType error:(NSError * _Nullable * _Nullable)error;
		[Abstract]
		[Export ("appendPartWithFileURL:name:fileName:mimeType:error:")]
		bool AppendPartWithFileURL (NSUrl fileURL, string name, string fileName, string mimeType, [NullAllowed] out NSError error);

		// @required -(void)appendPartWithInputStream:(NSInputStream * _Nullable)inputStream name:(NSString * _Nonnull)name fileName:(NSString * _Nonnull)fileName length:(int64_t)length mimeType:(NSString * _Nonnull)mimeType;
		[Abstract]
		[Export ("appendPartWithInputStream:name:fileName:length:mimeType:")]
		void AppendPartWithInputStream ([NullAllowed] NSInputStream inputStream, string name, string fileName, long length, string mimeType);

		// @required -(void)appendPartWithFileData:(NSData * _Nonnull)data name:(NSString * _Nonnull)name fileName:(NSString * _Nonnull)fileName mimeType:(NSString * _Nonnull)mimeType;
		[Abstract]
		[Export ("appendPartWithFileData:name:fileName:mimeType:")]
		void AppendPartWithFileData (NSData data, string name, string fileName, string mimeType);

		// @required -(void)appendPartWithFormData:(NSData * _Nonnull)data name:(NSString * _Nonnull)name;
		[Abstract]
		[Export ("appendPartWithFormData:name:")]
		void AppendPartWithFormData (NSData data, string name);

		// @required -(void)appendPartWithHeaders:(NSDictionary<NSString *,NSString *> * _Nullable)headers body:(NSData * _Nonnull)body;
		[Abstract]
		[Export ("appendPartWithHeaders:body:")]
		void AppendPartWithHeaders ([NullAllowed] NSDictionary<NSString, NSString> headers, NSData body);

		// @required -(void)throttleBandwidthWithPacketSize:(NSUInteger)numberOfBytes delay:(NSTimeInterval)delay;
		[Abstract]
		[Export ("throttleBandwidthWithPacketSize:delay:")]
		void ThrottleBandwidthWithPacketSize (nuint numberOfBytes, double delay);
	}

	// @interface AFJSONRequestSerializer : AFHTTPRequestSerializer
	[BaseType (typeof(AFHTTPRequestSerializer))]
	interface AFJSONRequestSerializer
	{
		// @property (assign, nonatomic) NSJSONWritingOptions writingOptions;
		[Export ("writingOptions", ArgumentSemantic.Assign)]
		NSJSONWritingOptions WritingOptions { get; set; }

		// +(instancetype _Nonnull)serializerWithWritingOptions:(NSJSONWritingOptions)writingOptions;
		[Static]
		[Export ("serializerWithWritingOptions:")]
		AFJSONRequestSerializer SerializerWithWritingOptions (NSJSONWritingOptions writingOptions);
	}

	// @interface AFPropertyListRequestSerializer : AFHTTPRequestSerializer
	[BaseType (typeof(AFHTTPRequestSerializer))]
	interface AFPropertyListRequestSerializer
	{
		// @property (assign, nonatomic) NSPropertyListFormat format;
		[Export ("format", ArgumentSemantic.Assign)]
		NSPropertyListFormat Format { get; set; }

		// @property (assign, nonatomic) NSPropertyListWriteOptions writeOptions;
		[Export ("writeOptions")]
		nuint WriteOptions { get; set; }

		// +(instancetype _Nonnull)serializerWithFormat:(NSPropertyListFormat)format writeOptions:(NSPropertyListWriteOptions)writeOptions;
		[Static]
		[Export ("serializerWithFormat:writeOptions:")]
		AFPropertyListRequestSerializer SerializerWithFormat (NSPropertyListFormat format, nuint writeOptions);
	}

	[Static]
	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const _Nonnull AFURLRequestSerializationErrorDomain;
		[Field ("AFURLRequestSerializationErrorDomain", "__Internal")]
		NSString AFURLRequestSerializationErrorDomain { get; }

		// extern NSString *const _Nonnull AFNetworkingOperationFailingURLRequestErrorKey;
		[Field ("AFNetworkingOperationFailingURLRequestErrorKey", "__Internal")]
		NSString AFNetworkingOperationFailingURLRequestErrorKey { get; }

		// extern const NSUInteger kAFUploadStream3GSuggestedPacketSize;
		[Field ("kAFUploadStream3GSuggestedPacketSize", "__Internal")]
		nuint kAFUploadStream3GSuggestedPacketSize { get; }

		// extern const NSTimeInterval kAFUploadStream3GSuggestedDelay;
		[Field ("kAFUploadStream3GSuggestedDelay", "__Internal")]
		double kAFUploadStream3GSuggestedDelay { get; }
	}

	// @protocol AFURLResponseSerialization <NSObject, NSSecureCoding, NSCopying>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface AFURLResponseSerialization : INSSecureCoding, INSCopying
	{
		// @required -(id _Nullable)responseObjectForResponse:(NSURLResponse * _Nullable)response data:(NSData * _Nullable)data error:(NSError * _Nullable * _Nullable)error;
		[Abstract]
		[Export ("responseObjectForResponse:data:error:")]
		[return: NullAllowed]
		NSObject Data ([NullAllowed] NSUrlResponse response, [NullAllowed] NSData data, [NullAllowed] out NSError error);
	}

	// @interface AFHTTPResponseSerializer : NSObject <AFURLResponseSerialization>
	[BaseType (typeof(NSObject))]
	interface AFHTTPResponseSerializer : IAFURLResponseSerialization
	{
		// @property (assign, nonatomic) NSStringEncoding stringEncoding;
		[Export ("stringEncoding")]
		nuint StringEncoding { get; set; }

		// +(instancetype _Nonnull)serializer;
		[Static]
		[Export ("serializer")]
		AFHTTPResponseSerializer Serializer ();

		// @property (copy, nonatomic) NSIndexSet * _Nullable acceptableStatusCodes;
		[NullAllowed, Export ("acceptableStatusCodes", ArgumentSemantic.Copy)]
		NSIndexSet AcceptableStatusCodes { get; set; }

		// @property (copy, nonatomic) NSSet<NSString *> * _Nullable acceptableContentTypes;
		[NullAllowed, Export ("acceptableContentTypes", ArgumentSemantic.Copy)]
		NSSet<NSString> AcceptableContentTypes { get; set; }

		// -(BOOL)validateResponse:(NSHTTPURLResponse * _Nullable)response data:(NSData * _Nullable)data error:(NSError * _Nullable * _Nullable)error;
		[Export ("validateResponse:data:error:")]
		bool ValidateResponse ([NullAllowed] NSHttpUrlResponse response, [NullAllowed] NSData data, [NullAllowed] out NSError error);
	}

	// @interface AFJSONResponseSerializer : AFHTTPResponseSerializer
	[BaseType (typeof(AFHTTPResponseSerializer))]
	interface AFJSONResponseSerializer
	{
		// @property (assign, nonatomic) NSJSONReadingOptions readingOptions;
		[Export ("readingOptions", ArgumentSemantic.Assign)]
		NSJSONReadingOptions ReadingOptions { get; set; }

		// @property (assign, nonatomic) BOOL removesKeysWithNullValues;
		[Export ("removesKeysWithNullValues")]
		bool RemovesKeysWithNullValues { get; set; }

		// +(instancetype _Nonnull)serializerWithReadingOptions:(NSJSONReadingOptions)readingOptions;
		[Static]
		[Export ("serializerWithReadingOptions:")]
		AFJSONResponseSerializer SerializerWithReadingOptions (NSJSONReadingOptions readingOptions);
	}

	// @interface AFXMLParserResponseSerializer : AFHTTPResponseSerializer
	[BaseType (typeof(AFHTTPResponseSerializer))]
	interface AFXMLParserResponseSerializer
	{
	}

	// @interface AFPropertyListResponseSerializer : AFHTTPResponseSerializer
	[BaseType (typeof(AFHTTPResponseSerializer))]
	interface AFPropertyListResponseSerializer
	{
		// @property (assign, nonatomic) NSPropertyListFormat format;
		[Export ("format", ArgumentSemantic.Assign)]
		NSPropertyListFormat Format { get; set; }

		// @property (assign, nonatomic) NSPropertyListReadOptions readOptions;
		[Export ("readOptions", ArgumentSemantic.Assign)]
		NSPropertyListReadOptions ReadOptions { get; set; }

		// +(instancetype _Nonnull)serializerWithFormat:(NSPropertyListFormat)format readOptions:(NSPropertyListReadOptions)readOptions;
		[Static]
		[Export ("serializerWithFormat:readOptions:")]
		AFPropertyListResponseSerializer SerializerWithFormat (NSPropertyListFormat format, NSPropertyListReadOptions readOptions);
	}

	// @interface AFImageResponseSerializer : AFHTTPResponseSerializer
	[BaseType (typeof(AFHTTPResponseSerializer))]
	interface AFImageResponseSerializer
	{
		// @property (assign, nonatomic) CGFloat imageScale;
		[Export ("imageScale")]
		nfloat ImageScale { get; set; }

		// @property (assign, nonatomic) BOOL automaticallyInflatesResponseImage;
		[Export ("automaticallyInflatesResponseImage")]
		bool AutomaticallyInflatesResponseImage { get; set; }
	}

	// @interface AFCompoundResponseSerializer : AFHTTPResponseSerializer
	[BaseType (typeof(AFHTTPResponseSerializer))]
	interface AFCompoundResponseSerializer
	{
		// @property (readonly, copy, nonatomic) NSArray<id<AFURLResponseSerialization>> * _Nonnull responseSerializers;
		[Export ("responseSerializers", ArgumentSemantic.Copy)]
		AFURLResponseSerialization[] ResponseSerializers { get; }

		// +(instancetype _Nonnull)compoundSerializerWithResponseSerializers:(NSArray<id<AFURLResponseSerialization>> * _Nonnull)responseSerializers;
		[Static]
		[Export ("compoundSerializerWithResponseSerializers:")]
		AFCompoundResponseSerializer CompoundSerializerWithResponseSerializers (AFURLResponseSerialization[] responseSerializers);
	}

	[Static]
	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const _Nonnull AFURLResponseSerializationErrorDomain;
		[Field ("AFURLResponseSerializationErrorDomain", "__Internal")]
		NSString AFURLResponseSerializationErrorDomain { get; }

		// extern NSString *const _Nonnull AFNetworkingOperationFailingURLResponseErrorKey;
		[Field ("AFNetworkingOperationFailingURLResponseErrorKey", "__Internal")]
		NSString AFNetworkingOperationFailingURLResponseErrorKey { get; }

		// extern NSString *const _Nonnull AFNetworkingOperationFailingURLResponseDataErrorKey;
		[Field ("AFNetworkingOperationFailingURLResponseDataErrorKey", "__Internal")]
		NSString AFNetworkingOperationFailingURLResponseDataErrorKey { get; }
	}

	// @interface AFSecurityPolicy : NSObject <NSSecureCoding, NSCopying>
	[BaseType (typeof(NSObject))]
	interface AFSecurityPolicy : INSSecureCoding, INSCopying
	{
		// @property (readonly, assign, nonatomic) AFSSLPinningMode SSLPinningMode;
		[Export ("SSLPinningMode", ArgumentSemantic.Assign)]
		AFSSLPinningMode SSLPinningMode { get; }

		// @property (nonatomic, strong) NSSet<NSData *> * _Nullable pinnedCertificates;
		[NullAllowed, Export ("pinnedCertificates", ArgumentSemantic.Strong)]
		NSSet<NSData> PinnedCertificates { get; set; }

		// @property (assign, nonatomic) BOOL allowInvalidCertificates;
		[Export ("allowInvalidCertificates")]
		bool AllowInvalidCertificates { get; set; }

		// @property (assign, nonatomic) BOOL validatesDomainName;
		[Export ("validatesDomainName")]
		bool ValidatesDomainName { get; set; }

		// +(NSSet<NSData *> * _Nonnull)certificatesInBundle:(NSBundle * _Nonnull)bundle;
		[Static]
		[Export ("certificatesInBundle:")]
		NSSet<NSData> CertificatesInBundle (NSBundle bundle);

		// +(instancetype _Nonnull)defaultPolicy;
		[Static]
		[Export ("defaultPolicy")]
		AFSecurityPolicy DefaultPolicy ();

		// +(instancetype _Nonnull)policyWithPinningMode:(AFSSLPinningMode)pinningMode;
		[Static]
		[Export ("policyWithPinningMode:")]
		AFSecurityPolicy PolicyWithPinningMode (AFSSLPinningMode pinningMode);

		// +(instancetype _Nonnull)policyWithPinningMode:(AFSSLPinningMode)pinningMode withPinnedCertificates:(NSSet<NSData *> * _Nonnull)pinnedCertificates;
		[Static]
		[Export ("policyWithPinningMode:withPinnedCertificates:")]
		AFSecurityPolicy PolicyWithPinningMode (AFSSLPinningMode pinningMode, NSSet<NSData> pinnedCertificates);

		// -(BOOL)evaluateServerTrust:(SecTrustRef _Nonnull)serverTrust forDomain:(NSString * _Nullable)domain;
		[Export ("evaluateServerTrust:forDomain:")]
		unsafe bool EvaluateServerTrust (SecTrustRef* serverTrust, [NullAllowed] string domain);
	}

	// @interface AFNetworkReachabilityManager : NSObject
	[BaseType (typeof(NSObject))]
	interface AFNetworkReachabilityManager
	{
		// @property (readonly, assign, nonatomic) AFNetworkReachabilityStatus networkReachabilityStatus;
		[Export ("networkReachabilityStatus", ArgumentSemantic.Assign)]
		AFNetworkReachabilityStatus NetworkReachabilityStatus { get; }

		// @property (readonly, getter = isReachable, assign, nonatomic) BOOL reachable;
		[Export ("reachable")]
		bool Reachable { [Bind ("isReachable")] get; }

		// @property (readonly, getter = isReachableViaWWAN, assign, nonatomic) BOOL reachableViaWWAN;
		[Export ("reachableViaWWAN")]
		bool ReachableViaWWAN { [Bind ("isReachableViaWWAN")] get; }

		// @property (readonly, getter = isReachableViaWiFi, assign, nonatomic) BOOL reachableViaWiFi;
		[Export ("reachableViaWiFi")]
		bool ReachableViaWiFi { [Bind ("isReachableViaWiFi")] get; }

		// +(instancetype _Nonnull)sharedManager;
		[Static]
		[Export ("sharedManager")]
		AFNetworkReachabilityManager SharedManager ();

		// +(instancetype _Nonnull)manager;
		[Static]
		[Export ("manager")]
		AFNetworkReachabilityManager Manager ();

		// +(instancetype _Nonnull)managerForDomain:(NSString * _Nonnull)domain;
		[Static]
		[Export ("managerForDomain:")]
		AFNetworkReachabilityManager ManagerForDomain (string domain);

		// +(instancetype _Nonnull)managerForAddress:(const void * _Nonnull)address;
		[Static]
		[Export ("managerForAddress:")]
		unsafe AFNetworkReachabilityManager ManagerForAddress (void* address);

		// -(instancetype _Nonnull)initWithReachability:(SCNetworkReachabilityRef _Nonnull)reachability __attribute__((objc_designated_initializer));
		[Export ("initWithReachability:")]
		[DesignatedInitializer]
		unsafe IntPtr Constructor (SCNetworkReachabilityRef* reachability);

		// -(void)startMonitoring;
		[Export ("startMonitoring")]
		void StartMonitoring ();

		// -(void)stopMonitoring;
		[Export ("stopMonitoring")]
		void StopMonitoring ();

		// -(NSString * _Nonnull)localizedNetworkReachabilityStatusString;
		[Export ("localizedNetworkReachabilityStatusString")]
		[Verify (MethodToProperty)]
		string LocalizedNetworkReachabilityStatusString { get; }

		// -(void)setReachabilityStatusChangeBlock:(void (^ _Nullable)(AFNetworkReachabilityStatus))block;
		[Export ("setReachabilityStatusChangeBlock:")]
		void SetReachabilityStatusChangeBlock ([NullAllowed] Action<AFNetworkReachabilityStatus> block);
	}

	[Static]
	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const _Nonnull AFNetworkingReachabilityDidChangeNotification;
		[Field ("AFNetworkingReachabilityDidChangeNotification", "__Internal")]
		NSString AFNetworkingReachabilityDidChangeNotification { get; }

		// extern NSString *const _Nonnull AFNetworkingReachabilityNotificationStatusItem;
		[Field ("AFNetworkingReachabilityNotificationStatusItem", "__Internal")]
		NSString AFNetworkingReachabilityNotificationStatusItem { get; }
	}

	// @interface AFURLSessionManager : NSObject <NSURLSessionDelegate, NSURLSessionTaskDelegate, NSURLSessionDataDelegate, NSURLSessionDownloadDelegate, NSSecureCoding, NSCopying>
	[BaseType (typeof(NSObject))]
	interface AFURLSessionManager : INSUrlSessionDelegate, INSUrlSessionTaskDelegate, INSUrlSessionDataDelegate, INSUrlSessionDownloadDelegate, INSSecureCoding, INSCopying
	{
		// @property (readonly, nonatomic, strong) NSURLSession * _Nonnull session;
		[Export ("session", ArgumentSemantic.Strong)]
		NSUrlSession Session { get; }

		// @property (readonly, nonatomic, strong) NSOperationQueue * _Nonnull operationQueue;
		[Export ("operationQueue", ArgumentSemantic.Strong)]
		NSOperationQueue OperationQueue { get; }

		// @property (nonatomic, strong) id<AFURLResponseSerialization> _Nonnull responseSerializer;
		[Export ("responseSerializer", ArgumentSemantic.Strong)]
		AFURLResponseSerialization ResponseSerializer { get; set; }

		// @property (nonatomic, strong) AFSecurityPolicy * _Nonnull securityPolicy;
		[Export ("securityPolicy", ArgumentSemantic.Strong)]
		AFSecurityPolicy SecurityPolicy { get; set; }

		// @property (readwrite, nonatomic, strong) AFNetworkReachabilityManager * _Nonnull reachabilityManager;
		[Export ("reachabilityManager", ArgumentSemantic.Strong)]
		AFNetworkReachabilityManager ReachabilityManager { get; set; }

		// @property (readonly, nonatomic, strong) NSArray<NSURLSessionTask *> * _Nonnull tasks;
		[Export ("tasks", ArgumentSemantic.Strong)]
		NSUrlSessionTask[] Tasks { get; }

		// @property (readonly, nonatomic, strong) NSArray<NSURLSessionDataTask *> * _Nonnull dataTasks;
		[Export ("dataTasks", ArgumentSemantic.Strong)]
		NSUrlSessionDataTask[] DataTasks { get; }

		// @property (readonly, nonatomic, strong) NSArray<NSURLSessionUploadTask *> * _Nonnull uploadTasks;
		[Export ("uploadTasks", ArgumentSemantic.Strong)]
		NSUrlSessionUploadTask[] UploadTasks { get; }

		// @property (readonly, nonatomic, strong) NSArray<NSURLSessionDownloadTask *> * _Nonnull downloadTasks;
		[Export ("downloadTasks", ArgumentSemantic.Strong)]
		NSUrlSessionDownloadTask[] DownloadTasks { get; }

		// @property (nonatomic, strong) dispatch_queue_t _Nullable completionQueue;
		[NullAllowed, Export ("completionQueue", ArgumentSemantic.Strong)]
		DispatchQueue CompletionQueue { get; set; }

		// @property (nonatomic, strong) dispatch_group_t _Nullable completionGroup;
		[NullAllowed, Export ("completionGroup", ArgumentSemantic.Strong)]
		DispatchGroup CompletionGroup { get; set; }

		// @property (assign, nonatomic) BOOL attemptsToRecreateUploadTasksForBackgroundSessions;
		[Export ("attemptsToRecreateUploadTasksForBackgroundSessions")]
		bool AttemptsToRecreateUploadTasksForBackgroundSessions { get; set; }

		// -(instancetype _Nonnull)initWithSessionConfiguration:(NSURLSessionConfiguration * _Nullable)configuration __attribute__((objc_designated_initializer));
		[Export ("initWithSessionConfiguration:")]
		[DesignatedInitializer]
		IntPtr Constructor ([NullAllowed] NSUrlSessionConfiguration configuration);

		// -(void)invalidateSessionCancelingTasks:(BOOL)cancelPendingTasks;
		[Export ("invalidateSessionCancelingTasks:")]
		void InvalidateSessionCancelingTasks (bool cancelPendingTasks);

		// -(NSURLSessionDataTask * _Nonnull)dataTaskWithRequest:(NSURLRequest * _Nonnull)request completionHandler:(void (^ _Nullable)(NSURLResponse * _Nonnull, id _Nullable, NSError * _Nullable))completionHandler;
		[Export ("dataTaskWithRequest:completionHandler:")]
		NSUrlSessionDataTask DataTaskWithRequest (NSUrlRequest request, [NullAllowed] Action<NSURLResponse, NSObject, NSError> completionHandler);

		// -(NSURLSessionDataTask * _Nonnull)dataTaskWithRequest:(NSURLRequest * _Nonnull)request uploadProgress:(void (^ _Nullable)(NSProgress * _Nonnull))uploadProgressBlock downloadProgress:(void (^ _Nullable)(NSProgress * _Nonnull))downloadProgressBlock completionHandler:(void (^ _Nullable)(NSURLResponse * _Nonnull, id _Nullable, NSError * _Nullable))completionHandler;
		[Export ("dataTaskWithRequest:uploadProgress:downloadProgress:completionHandler:")]
		NSUrlSessionDataTask DataTaskWithRequest (NSUrlRequest request, [NullAllowed] Action<NSProgress> uploadProgressBlock, [NullAllowed] Action<NSProgress> downloadProgressBlock, [NullAllowed] Action<NSURLResponse, NSObject, NSError> completionHandler);

		// -(NSURLSessionUploadTask * _Nonnull)uploadTaskWithRequest:(NSURLRequest * _Nonnull)request fromFile:(NSURL * _Nonnull)fileURL progress:(void (^ _Nullable)(NSProgress * _Nonnull))uploadProgressBlock completionHandler:(void (^ _Nullable)(NSURLResponse * _Nonnull, id _Nullable, NSError * _Nullable))completionHandler;
		[Export ("uploadTaskWithRequest:fromFile:progress:completionHandler:")]
		NSUrlSessionUploadTask UploadTaskWithRequest (NSUrlRequest request, NSUrl fileURL, [NullAllowed] Action<NSProgress> uploadProgressBlock, [NullAllowed] Action<NSURLResponse, NSObject, NSError> completionHandler);

		// -(NSURLSessionUploadTask * _Nonnull)uploadTaskWithRequest:(NSURLRequest * _Nonnull)request fromData:(NSData * _Nullable)bodyData progress:(void (^ _Nullable)(NSProgress * _Nonnull))uploadProgressBlock completionHandler:(void (^ _Nullable)(NSURLResponse * _Nonnull, id _Nullable, NSError * _Nullable))completionHandler;
		[Export ("uploadTaskWithRequest:fromData:progress:completionHandler:")]
		NSUrlSessionUploadTask UploadTaskWithRequest (NSUrlRequest request, [NullAllowed] NSData bodyData, [NullAllowed] Action<NSProgress> uploadProgressBlock, [NullAllowed] Action<NSURLResponse, NSObject, NSError> completionHandler);

		// -(NSURLSessionUploadTask * _Nonnull)uploadTaskWithStreamedRequest:(NSURLRequest * _Nonnull)request progress:(void (^ _Nullable)(NSProgress * _Nonnull))uploadProgressBlock completionHandler:(void (^ _Nullable)(NSURLResponse * _Nonnull, id _Nullable, NSError * _Nullable))completionHandler;
		[Export ("uploadTaskWithStreamedRequest:progress:completionHandler:")]
		NSUrlSessionUploadTask UploadTaskWithStreamedRequest (NSUrlRequest request, [NullAllowed] Action<NSProgress> uploadProgressBlock, [NullAllowed] Action<NSURLResponse, NSObject, NSError> completionHandler);

		// -(NSURLSessionDownloadTask * _Nonnull)downloadTaskWithRequest:(NSURLRequest * _Nonnull)request progress:(void (^ _Nullable)(NSProgress * _Nonnull))downloadProgressBlock destination:(NSURL * _Nonnull (^ _Nullable)(NSURL * _Nonnull, NSURLResponse * _Nonnull))destination completionHandler:(void (^ _Nullable)(NSURLResponse * _Nonnull, NSURL * _Nullable, NSError * _Nullable))completionHandler;
		[Export ("downloadTaskWithRequest:progress:destination:completionHandler:")]
		NSUrlSessionDownloadTask DownloadTaskWithRequest (NSUrlRequest request, [NullAllowed] Action<NSProgress> downloadProgressBlock, [NullAllowed] Func<NSURL, NSURLResponse, NSURL> destination, [NullAllowed] Action<NSURLResponse, NSURL, NSError> completionHandler);

		// -(NSURLSessionDownloadTask * _Nonnull)downloadTaskWithResumeData:(NSData * _Nonnull)resumeData progress:(void (^ _Nullable)(NSProgress * _Nonnull))downloadProgressBlock destination:(NSURL * _Nonnull (^ _Nullable)(NSURL * _Nonnull, NSURLResponse * _Nonnull))destination completionHandler:(void (^ _Nullable)(NSURLResponse * _Nonnull, NSURL * _Nullable, NSError * _Nullable))completionHandler;
		[Export ("downloadTaskWithResumeData:progress:destination:completionHandler:")]
		NSUrlSessionDownloadTask DownloadTaskWithResumeData (NSData resumeData, [NullAllowed] Action<NSProgress> downloadProgressBlock, [NullAllowed] Func<NSURL, NSURLResponse, NSURL> destination, [NullAllowed] Action<NSURLResponse, NSURL, NSError> completionHandler);

		// -(NSProgress * _Nullable)uploadProgressForTask:(NSURLSessionTask * _Nonnull)task;
		[Export ("uploadProgressForTask:")]
		[return: NullAllowed]
		NSProgress UploadProgressForTask (NSUrlSessionTask task);

		// -(NSProgress * _Nullable)downloadProgressForTask:(NSURLSessionTask * _Nonnull)task;
		[Export ("downloadProgressForTask:")]
		[return: NullAllowed]
		NSProgress DownloadProgressForTask (NSUrlSessionTask task);

		// -(void)setSessionDidBecomeInvalidBlock:(void (^ _Nullable)(NSURLSession * _Nonnull, NSError * _Nonnull))block;
		[Export ("setSessionDidBecomeInvalidBlock:")]
		void SetSessionDidBecomeInvalidBlock ([NullAllowed] Action<NSURLSession, NSError> block);

		// -(void)setSessionDidReceiveAuthenticationChallengeBlock:(NSURLSessionAuthChallengeDisposition (^ _Nullable)(NSURLSession * _Nonnull, NSURLAuthenticationChallenge * _Nonnull, NSURLCredential * _Nullable * _Nullable))block;
		[Export ("setSessionDidReceiveAuthenticationChallengeBlock:")]
		unsafe void SetSessionDidReceiveAuthenticationChallengeBlock ([NullAllowed] Func<NSURLSession, NSURLAuthenticationChallenge, Foundation.NSURLCredential*, NSURLSessionAuthChallengeDisposition> block);

		// -(void)setTaskNeedNewBodyStreamBlock:(NSInputStream * _Nonnull (^ _Nullable)(NSURLSession * _Nonnull, NSURLSessionTask * _Nonnull))block;
		[Export ("setTaskNeedNewBodyStreamBlock:")]
		void SetTaskNeedNewBodyStreamBlock ([NullAllowed] Func<NSURLSession, NSURLSessionTask, NSInputStream> block);

		// -(void)setTaskWillPerformHTTPRedirectionBlock:(NSURLRequest * _Nonnull (^ _Nullable)(NSURLSession * _Nonnull, NSURLSessionTask * _Nonnull, NSURLResponse * _Nonnull, NSURLRequest * _Nonnull))block;
		[Export ("setTaskWillPerformHTTPRedirectionBlock:")]
		void SetTaskWillPerformHTTPRedirectionBlock ([NullAllowed] Func<NSURLSession, NSURLSessionTask, NSURLResponse, NSURLRequest, NSURLRequest> block);

		// -(void)setTaskDidReceiveAuthenticationChallengeBlock:(NSURLSessionAuthChallengeDisposition (^ _Nullable)(NSURLSession * _Nonnull, NSURLSessionTask * _Nonnull, NSURLAuthenticationChallenge * _Nonnull, NSURLCredential * _Nullable * _Nullable))block;
		[Export ("setTaskDidReceiveAuthenticationChallengeBlock:")]
		unsafe void SetTaskDidReceiveAuthenticationChallengeBlock ([NullAllowed] Func<NSURLSession, NSURLSessionTask, NSURLAuthenticationChallenge, Foundation.NSURLCredential*, NSURLSessionAuthChallengeDisposition> block);

		// -(void)setTaskDidSendBodyDataBlock:(void (^ _Nullable)(NSURLSession * _Nonnull, NSURLSessionTask * _Nonnull, int64_t, int64_t, int64_t))block;
		[Export ("setTaskDidSendBodyDataBlock:")]
		void SetTaskDidSendBodyDataBlock ([NullAllowed] Action<NSURLSession, NSURLSessionTask, long, long, long> block);

		// -(void)setTaskDidCompleteBlock:(void (^ _Nullable)(NSURLSession * _Nonnull, NSURLSessionTask * _Nonnull, NSError * _Nullable))block;
		[Export ("setTaskDidCompleteBlock:")]
		void SetTaskDidCompleteBlock ([NullAllowed] Action<NSURLSession, NSURLSessionTask, NSError> block);

		// -(void)setDataTaskDidReceiveResponseBlock:(NSURLSessionResponseDisposition (^ _Nullable)(NSURLSession * _Nonnull, NSURLSessionDataTask * _Nonnull, NSURLResponse * _Nonnull))block;
		[Export ("setDataTaskDidReceiveResponseBlock:")]
		void SetDataTaskDidReceiveResponseBlock ([NullAllowed] Func<NSURLSession, NSURLSessionDataTask, NSURLResponse, NSURLSessionResponseDisposition> block);

		// -(void)setDataTaskDidBecomeDownloadTaskBlock:(void (^ _Nullable)(NSURLSession * _Nonnull, NSURLSessionDataTask * _Nonnull, NSURLSessionDownloadTask * _Nonnull))block;
		[Export ("setDataTaskDidBecomeDownloadTaskBlock:")]
		void SetDataTaskDidBecomeDownloadTaskBlock ([NullAllowed] Action<NSURLSession, NSURLSessionDataTask, NSURLSessionDownloadTask> block);

		// -(void)setDataTaskDidReceiveDataBlock:(void (^ _Nullable)(NSURLSession * _Nonnull, NSURLSessionDataTask * _Nonnull, NSData * _Nonnull))block;
		[Export ("setDataTaskDidReceiveDataBlock:")]
		void SetDataTaskDidReceiveDataBlock ([NullAllowed] Action<NSURLSession, NSURLSessionDataTask, NSData> block);

		// -(void)setDataTaskWillCacheResponseBlock:(NSCachedURLResponse * _Nonnull (^ _Nullable)(NSURLSession * _Nonnull, NSURLSessionDataTask * _Nonnull, NSCachedURLResponse * _Nonnull))block;
		[Export ("setDataTaskWillCacheResponseBlock:")]
		void SetDataTaskWillCacheResponseBlock ([NullAllowed] Func<NSURLSession, NSURLSessionDataTask, NSCachedURLResponse, NSCachedURLResponse> block);

		// -(void)setDidFinishEventsForBackgroundURLSessionBlock:(void (^ _Nullable)(NSURLSession * _Nonnull))block;
		[Export ("setDidFinishEventsForBackgroundURLSessionBlock:")]
		void SetDidFinishEventsForBackgroundURLSessionBlock ([NullAllowed] Action<NSURLSession> block);

		// -(void)setDownloadTaskDidFinishDownloadingBlock:(NSURL * _Nullable (^ _Nullable)(NSURLSession * _Nonnull, NSURLSessionDownloadTask * _Nonnull, NSURL * _Nonnull))block;
		[Export ("setDownloadTaskDidFinishDownloadingBlock:")]
		void SetDownloadTaskDidFinishDownloadingBlock ([NullAllowed] Func<NSURLSession, NSURLSessionDownloadTask, NSURL, NSURL> block);

		// -(void)setDownloadTaskDidWriteDataBlock:(void (^ _Nullable)(NSURLSession * _Nonnull, NSURLSessionDownloadTask * _Nonnull, int64_t, int64_t, int64_t))block;
		[Export ("setDownloadTaskDidWriteDataBlock:")]
		void SetDownloadTaskDidWriteDataBlock ([NullAllowed] Action<NSURLSession, NSURLSessionDownloadTask, long, long, long> block);

		// -(void)setDownloadTaskDidResumeBlock:(void (^ _Nullable)(NSURLSession * _Nonnull, NSURLSessionDownloadTask * _Nonnull, int64_t, int64_t))block;
		[Export ("setDownloadTaskDidResumeBlock:")]
		void SetDownloadTaskDidResumeBlock ([NullAllowed] Action<NSURLSession, NSURLSessionDownloadTask, long, long> block);
	}

	[Static]
	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const _Nonnull AFNetworkingTaskDidResumeNotification;
		[Field ("AFNetworkingTaskDidResumeNotification", "__Internal")]
		NSString AFNetworkingTaskDidResumeNotification { get; }

		// extern NSString *const _Nonnull AFNetworkingTaskDidCompleteNotification;
		[Field ("AFNetworkingTaskDidCompleteNotification", "__Internal")]
		NSString AFNetworkingTaskDidCompleteNotification { get; }

		// extern NSString *const _Nonnull AFNetworkingTaskDidSuspendNotification;
		[Field ("AFNetworkingTaskDidSuspendNotification", "__Internal")]
		NSString AFNetworkingTaskDidSuspendNotification { get; }

		// extern NSString *const _Nonnull AFURLSessionDidInvalidateNotification;
		[Field ("AFURLSessionDidInvalidateNotification", "__Internal")]
		NSString AFURLSessionDidInvalidateNotification { get; }

		// extern NSString *const _Nonnull AFURLSessionDownloadTaskDidFailToMoveFileNotification;
		[Field ("AFURLSessionDownloadTaskDidFailToMoveFileNotification", "__Internal")]
		NSString AFURLSessionDownloadTaskDidFailToMoveFileNotification { get; }

		// extern NSString *const _Nonnull AFNetworkingTaskDidCompleteResponseDataKey;
		[Field ("AFNetworkingTaskDidCompleteResponseDataKey", "__Internal")]
		NSString AFNetworkingTaskDidCompleteResponseDataKey { get; }

		// extern NSString *const _Nonnull AFNetworkingTaskDidCompleteSerializedResponseKey;
		[Field ("AFNetworkingTaskDidCompleteSerializedResponseKey", "__Internal")]
		NSString AFNetworkingTaskDidCompleteSerializedResponseKey { get; }

		// extern NSString *const _Nonnull AFNetworkingTaskDidCompleteResponseSerializerKey;
		[Field ("AFNetworkingTaskDidCompleteResponseSerializerKey", "__Internal")]
		NSString AFNetworkingTaskDidCompleteResponseSerializerKey { get; }

		// extern NSString *const _Nonnull AFNetworkingTaskDidCompleteAssetPathKey;
		[Field ("AFNetworkingTaskDidCompleteAssetPathKey", "__Internal")]
		NSString AFNetworkingTaskDidCompleteAssetPathKey { get; }

		// extern NSString *const _Nonnull AFNetworkingTaskDidCompleteErrorKey;
		[Field ("AFNetworkingTaskDidCompleteErrorKey", "__Internal")]
		NSString AFNetworkingTaskDidCompleteErrorKey { get; }
	}

	// @interface AFHTTPSessionManager : AFURLSessionManager <NSSecureCoding, NSCopying>
	[BaseType (typeof(AFURLSessionManager))]
	interface AFHTTPSessionManager : INSSecureCoding, INSCopying
	{
		// @property (readonly, nonatomic, strong) NSURL * _Nullable baseURL;
		[NullAllowed, Export ("baseURL", ArgumentSemantic.Strong)]
		NSUrl BaseURL { get; }

		// @property (nonatomic, strong) AFHTTPRequestSerializer<AFURLRequestSerialization> * _Nonnull requestSerializer;
		[Export ("requestSerializer", ArgumentSemantic.Strong)]
		AFURLRequestSerialization RequestSerializer { get; set; }

		// @property (nonatomic, strong) AFHTTPResponseSerializer<AFURLResponseSerialization> * _Nonnull responseSerializer;
		[Export ("responseSerializer", ArgumentSemantic.Strong)]
		AFURLResponseSerialization ResponseSerializer { get; set; }

		// +(instancetype _Nonnull)manager;
		[Static]
		[Export ("manager")]
		AFHTTPSessionManager Manager ();

		// -(instancetype _Nonnull)initWithBaseURL:(NSURL * _Nullable)url;
		[Export ("initWithBaseURL:")]
		IntPtr Constructor ([NullAllowed] NSUrl url);

		// -(instancetype _Nonnull)initWithBaseURL:(NSURL * _Nullable)url sessionConfiguration:(NSURLSessionConfiguration * _Nullable)configuration __attribute__((objc_designated_initializer));
		[Export ("initWithBaseURL:sessionConfiguration:")]
		[DesignatedInitializer]
		IntPtr Constructor ([NullAllowed] NSUrl url, [NullAllowed] NSUrlSessionConfiguration configuration);

		// -(NSURLSessionDataTask * _Nullable)GET:(NSString * _Nonnull)URLString parameters:(id _Nullable)parameters success:(void (^ _Nullable)(NSURLSessionDataTask * _Nonnull, id _Nullable))success failure:(void (^ _Nullable)(NSURLSessionDataTask * _Nullable, NSError * _Nonnull))failure __attribute__((deprecated("")));
		[Export ("GET:parameters:success:failure:")]
		[return: NullAllowed]
		NSUrlSessionDataTask GET (string URLString, [NullAllowed] NSObject parameters, [NullAllowed] Action<NSURLSessionDataTask, NSObject> success, [NullAllowed] Action<NSURLSessionDataTask, NSError> failure);

		// -(NSURLSessionDataTask * _Nullable)GET:(NSString * _Nonnull)URLString parameters:(id _Nullable)parameters progress:(void (^ _Nullable)(NSProgress * _Nonnull))downloadProgress success:(void (^ _Nullable)(NSURLSessionDataTask * _Nonnull, id _Nullable))success failure:(void (^ _Nullable)(NSURLSessionDataTask * _Nullable, NSError * _Nonnull))failure;
		[Export ("GET:parameters:progress:success:failure:")]
		[return: NullAllowed]
		NSUrlSessionDataTask GET (string URLString, [NullAllowed] NSObject parameters, [NullAllowed] Action<NSProgress> downloadProgress, [NullAllowed] Action<NSURLSessionDataTask, NSObject> success, [NullAllowed] Action<NSURLSessionDataTask, NSError> failure);

		// -(NSURLSessionDataTask * _Nullable)HEAD:(NSString * _Nonnull)URLString parameters:(id _Nullable)parameters success:(void (^ _Nullable)(NSURLSessionDataTask * _Nonnull))success failure:(void (^ _Nullable)(NSURLSessionDataTask * _Nullable, NSError * _Nonnull))failure;
		[Export ("HEAD:parameters:success:failure:")]
		[return: NullAllowed]
		NSUrlSessionDataTask HEAD (string URLString, [NullAllowed] NSObject parameters, [NullAllowed] Action<NSURLSessionDataTask> success, [NullAllowed] Action<NSURLSessionDataTask, NSError> failure);

		// -(NSURLSessionDataTask * _Nullable)POST:(NSString * _Nonnull)URLString parameters:(id _Nullable)parameters success:(void (^ _Nullable)(NSURLSessionDataTask * _Nonnull, id _Nullable))success failure:(void (^ _Nullable)(NSURLSessionDataTask * _Nullable, NSError * _Nonnull))failure __attribute__((deprecated("")));
		[Export ("POST:parameters:success:failure:")]
		[return: NullAllowed]
		NSUrlSessionDataTask POST (string URLString, [NullAllowed] NSObject parameters, [NullAllowed] Action<NSURLSessionDataTask, NSObject> success, [NullAllowed] Action<NSURLSessionDataTask, NSError> failure);

		// -(NSURLSessionDataTask * _Nullable)POST:(NSString * _Nonnull)URLString parameters:(id _Nullable)parameters progress:(void (^ _Nullable)(NSProgress * _Nonnull))uploadProgress success:(void (^ _Nullable)(NSURLSessionDataTask * _Nonnull, id _Nullable))success failure:(void (^ _Nullable)(NSURLSessionDataTask * _Nullable, NSError * _Nonnull))failure;
		[Export ("POST:parameters:progress:success:failure:")]
		[return: NullAllowed]
		NSUrlSessionDataTask POST (string URLString, [NullAllowed] NSObject parameters, [NullAllowed] Action<NSProgress> uploadProgress, [NullAllowed] Action<NSURLSessionDataTask, NSObject> success, [NullAllowed] Action<NSURLSessionDataTask, NSError> failure);

		// -(NSURLSessionDataTask * _Nullable)POST:(NSString * _Nonnull)URLString parameters:(id _Nullable)parameters constructingBodyWithBlock:(void (^ _Nullable)(id<AFMultipartFormData> _Nonnull))block success:(void (^ _Nullable)(NSURLSessionDataTask * _Nonnull, id _Nullable))success failure:(void (^ _Nullable)(NSURLSessionDataTask * _Nullable, NSError * _Nonnull))failure __attribute__((deprecated("")));
		[Export ("POST:parameters:constructingBodyWithBlock:success:failure:")]
		[return: NullAllowed]
		NSUrlSessionDataTask POST (string URLString, [NullAllowed] NSObject parameters, [NullAllowed] Action<AFMultipartFormData> block, [NullAllowed] Action<NSURLSessionDataTask, NSObject> success, [NullAllowed] Action<NSURLSessionDataTask, NSError> failure);

		// -(NSURLSessionDataTask * _Nullable)POST:(NSString * _Nonnull)URLString parameters:(id _Nullable)parameters constructingBodyWithBlock:(void (^ _Nullable)(id<AFMultipartFormData> _Nonnull))block progress:(void (^ _Nullable)(NSProgress * _Nonnull))uploadProgress success:(void (^ _Nullable)(NSURLSessionDataTask * _Nonnull, id _Nullable))success failure:(void (^ _Nullable)(NSURLSessionDataTask * _Nullable, NSError * _Nonnull))failure;
		[Export ("POST:parameters:constructingBodyWithBlock:progress:success:failure:")]
		[return: NullAllowed]
		NSUrlSessionDataTask POST (string URLString, [NullAllowed] NSObject parameters, [NullAllowed] Action<AFMultipartFormData> block, [NullAllowed] Action<NSProgress> uploadProgress, [NullAllowed] Action<NSURLSessionDataTask, NSObject> success, [NullAllowed] Action<NSURLSessionDataTask, NSError> failure);

		// -(NSURLSessionDataTask * _Nullable)PUT:(NSString * _Nonnull)URLString parameters:(id _Nullable)parameters success:(void (^ _Nullable)(NSURLSessionDataTask * _Nonnull, id _Nullable))success failure:(void (^ _Nullable)(NSURLSessionDataTask * _Nullable, NSError * _Nonnull))failure;
		[Export ("PUT:parameters:success:failure:")]
		[return: NullAllowed]
		NSUrlSessionDataTask PUT (string URLString, [NullAllowed] NSObject parameters, [NullAllowed] Action<NSURLSessionDataTask, NSObject> success, [NullAllowed] Action<NSURLSessionDataTask, NSError> failure);

		// -(NSURLSessionDataTask * _Nullable)PATCH:(NSString * _Nonnull)URLString parameters:(id _Nullable)parameters success:(void (^ _Nullable)(NSURLSessionDataTask * _Nonnull, id _Nullable))success failure:(void (^ _Nullable)(NSURLSessionDataTask * _Nullable, NSError * _Nonnull))failure;
		[Export ("PATCH:parameters:success:failure:")]
		[return: NullAllowed]
		NSUrlSessionDataTask PATCH (string URLString, [NullAllowed] NSObject parameters, [NullAllowed] Action<NSURLSessionDataTask, NSObject> success, [NullAllowed] Action<NSURLSessionDataTask, NSError> failure);

		// -(NSURLSessionDataTask * _Nullable)DELETE:(NSString * _Nonnull)URLString parameters:(id _Nullable)parameters success:(void (^ _Nullable)(NSURLSessionDataTask * _Nonnull, id _Nullable))success failure:(void (^ _Nullable)(NSURLSessionDataTask * _Nullable, NSError * _Nonnull))failure;
		[Export ("DELETE:parameters:success:failure:")]
		[return: NullAllowed]
		NSUrlSessionDataTask DELETE (string URLString, [NullAllowed] NSObject parameters, [NullAllowed] Action<NSURLSessionDataTask, NSObject> success, [NullAllowed] Action<NSURLSessionDataTask, NSError> failure);
	}

	// @protocol AFImageCache <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface AFImageCache
	{
		// @required -(void)addImage:(UIImage * _Nonnull)image withIdentifier:(NSString * _Nonnull)identifier;
		[Abstract]
		[Export ("addImage:withIdentifier:")]
		void AddImage (UIImage image, string identifier);

		// @required -(BOOL)removeImageWithIdentifier:(NSString * _Nonnull)identifier;
		[Abstract]
		[Export ("removeImageWithIdentifier:")]
		bool RemoveImageWithIdentifier (string identifier);

		// @required -(BOOL)removeAllImages;
		[Abstract]
		[Export ("removeAllImages")]
		[Verify (MethodToProperty)]
		bool RemoveAllImages { get; }

		// @required -(UIImage * _Nullable)imageWithIdentifier:(NSString * _Nonnull)identifier;
		[Abstract]
		[Export ("imageWithIdentifier:")]
		[return: NullAllowed]
		UIImage ImageWithIdentifier (string identifier);
	}

	// @protocol AFImageRequestCache <AFImageCache>
	[Protocol, Model]
	interface AFImageRequestCache : IAFImageCache
	{
		// @required -(void)addImage:(UIImage * _Nonnull)image forRequest:(NSURLRequest * _Nonnull)request withAdditionalIdentifier:(NSString * _Nullable)identifier;
		[Abstract]
		[Export ("addImage:forRequest:withAdditionalIdentifier:")]
		void AddImage (UIImage image, NSUrlRequest request, [NullAllowed] string identifier);

		// @required -(BOOL)removeImageforRequest:(NSURLRequest * _Nonnull)request withAdditionalIdentifier:(NSString * _Nullable)identifier;
		[Abstract]
		[Export ("removeImageforRequest:withAdditionalIdentifier:")]
		bool RemoveImageforRequest (NSUrlRequest request, [NullAllowed] string identifier);

		// @required -(UIImage * _Nullable)imageforRequest:(NSURLRequest * _Nonnull)request withAdditionalIdentifier:(NSString * _Nullable)identifier;
		[Abstract]
		[Export ("imageforRequest:withAdditionalIdentifier:")]
		[return: NullAllowed]
		UIImage ImageforRequest (NSUrlRequest request, [NullAllowed] string identifier);
	}

	// @interface AFAutoPurgingImageCache : NSObject <AFImageRequestCache>
	[BaseType (typeof(NSObject))]
	interface AFAutoPurgingImageCache : IAFImageRequestCache
	{
		// @property (assign, nonatomic) UInt64 memoryCapacity;
		[Export ("memoryCapacity")]
		ulong MemoryCapacity { get; set; }

		// @property (assign, nonatomic) UInt64 preferredMemoryUsageAfterPurge;
		[Export ("preferredMemoryUsageAfterPurge")]
		ulong PreferredMemoryUsageAfterPurge { get; set; }

		// @property (readonly, assign, nonatomic) UInt64 memoryUsage;
		[Export ("memoryUsage")]
		ulong MemoryUsage { get; }

		// -(instancetype _Nonnull)initWithMemoryCapacity:(UInt64)memoryCapacity preferredMemoryCapacity:(UInt64)preferredMemoryCapacity;
		[Export ("initWithMemoryCapacity:preferredMemoryCapacity:")]
		IntPtr Constructor (ulong memoryCapacity, ulong preferredMemoryCapacity);
	}

	// @interface AFImageDownloadReceipt : NSObject
	[BaseType (typeof(NSObject))]
	interface AFImageDownloadReceipt
	{
		// @property (nonatomic, strong) NSURLSessionDataTask * _Nonnull task;
		[Export ("task", ArgumentSemantic.Strong)]
		NSUrlSessionDataTask Task { get; set; }

		// @property (nonatomic, strong) NSUUID * _Nonnull receiptID;
		[Export ("receiptID", ArgumentSemantic.Strong)]
		NSUuid ReceiptID { get; set; }
	}

	// @interface AFImageDownloader : NSObject
	[BaseType (typeof(NSObject))]
	interface AFImageDownloader
	{
		// @property (nonatomic, strong) id<AFImageRequestCache> _Nullable imageCache;
		[NullAllowed, Export ("imageCache", ArgumentSemantic.Strong)]
		AFImageRequestCache ImageCache { get; set; }

		// @property (nonatomic, strong) AFHTTPSessionManager * _Nonnull sessionManager;
		[Export ("sessionManager", ArgumentSemantic.Strong)]
		AFHTTPSessionManager SessionManager { get; set; }

		// @property (assign, nonatomic) AFImageDownloadPrioritization downloadPrioritizaton;
		[Export ("downloadPrioritizaton", ArgumentSemantic.Assign)]
		AFImageDownloadPrioritization DownloadPrioritizaton { get; set; }

		// +(instancetype _Nonnull)defaultInstance;
		[Static]
		[Export ("defaultInstance")]
		AFImageDownloader DefaultInstance ();

		// +(NSURLCache * _Nonnull)defaultURLCache;
		[Static]
		[Export ("defaultURLCache")]
		[Verify (MethodToProperty)]
		NSUrlCache DefaultURLCache { get; }

		// -(instancetype _Nonnull)initWithSessionManager:(AFHTTPSessionManager * _Nonnull)sessionManager downloadPrioritization:(AFImageDownloadPrioritization)downloadPrioritization maximumActiveDownloads:(NSInteger)maximumActiveDownloads imageCache:(id<AFImageRequestCache> _Nullable)imageCache;
		[Export ("initWithSessionManager:downloadPrioritization:maximumActiveDownloads:imageCache:")]
		IntPtr Constructor (AFHTTPSessionManager sessionManager, AFImageDownloadPrioritization downloadPrioritization, nint maximumActiveDownloads, [NullAllowed] AFImageRequestCache imageCache);

		// -(AFImageDownloadReceipt * _Nullable)downloadImageForURLRequest:(NSURLRequest * _Nonnull)request success:(void (^ _Nullable)(NSURLRequest * _Nonnull, NSHTTPURLResponse * _Nullable, UIImage * _Nonnull))success failure:(void (^ _Nullable)(NSURLRequest * _Nonnull, NSHTTPURLResponse * _Nullable, NSError * _Nonnull))failure;
		[Export ("downloadImageForURLRequest:success:failure:")]
		[return: NullAllowed]
		AFImageDownloadReceipt DownloadImageForURLRequest (NSUrlRequest request, [NullAllowed] Action<NSURLRequest, NSHTTPURLResponse, UIImage> success, [NullAllowed] Action<NSURLRequest, NSHTTPURLResponse, NSError> failure);

		// -(AFImageDownloadReceipt * _Nullable)downloadImageForURLRequest:(NSURLRequest * _Nonnull)request withReceiptID:(NSUUID * _Nonnull)receiptID success:(void (^ _Nullable)(NSURLRequest * _Nonnull, NSHTTPURLResponse * _Nullable, UIImage * _Nonnull))success failure:(void (^ _Nullable)(NSURLRequest * _Nonnull, NSHTTPURLResponse * _Nullable, NSError * _Nonnull))failure;
		[Export ("downloadImageForURLRequest:withReceiptID:success:failure:")]
		[return: NullAllowed]
		AFImageDownloadReceipt DownloadImageForURLRequest (NSUrlRequest request, NSUuid receiptID, [NullAllowed] Action<NSURLRequest, NSHTTPURLResponse, UIImage> success, [NullAllowed] Action<NSURLRequest, NSHTTPURLResponse, NSError> failure);

		// -(void)cancelTaskForImageDownloadReceipt:(AFImageDownloadReceipt * _Nonnull)imageDownloadReceipt;
		[Export ("cancelTaskForImageDownloadReceipt:")]
		void CancelTaskForImageDownloadReceipt (AFImageDownloadReceipt imageDownloadReceipt);
	}

	// @interface AFNetworkActivityIndicatorManager : NSObject
	[Unavailable (PlatformName.iOSAppExtension)]
	[BaseType (typeof(NSObject))]
	interface AFNetworkActivityIndicatorManager
	{
		// @property (getter = isEnabled, assign, nonatomic) BOOL enabled;
		[Export ("enabled")]
		bool Enabled { [Bind ("isEnabled")] get; set; }

		// @property (readonly, getter = isNetworkActivityIndicatorVisible, assign, nonatomic) BOOL networkActivityIndicatorVisible;
		[Export ("networkActivityIndicatorVisible")]
		bool NetworkActivityIndicatorVisible { [Bind ("isNetworkActivityIndicatorVisible")] get; }

		// @property (assign, nonatomic) NSTimeInterval activationDelay;
		[Export ("activationDelay")]
		double ActivationDelay { get; set; }

		// @property (assign, nonatomic) NSTimeInterval completionDelay;
		[Export ("completionDelay")]
		double CompletionDelay { get; set; }

		// +(instancetype _Nonnull)sharedManager;
		[Static]
		[Export ("sharedManager")]
		AFNetworkActivityIndicatorManager SharedManager ();

		// -(void)incrementActivityCount;
		[Export ("incrementActivityCount")]
		void IncrementActivityCount ();

		// -(void)decrementActivityCount;
		[Export ("decrementActivityCount")]
		void DecrementActivityCount ();

		// -(void)setNetworkingActivityActionWithBlock:(void (^ _Nullable)(BOOL))block;
		[Export ("setNetworkingActivityActionWithBlock:")]
		void SetNetworkingActivityActionWithBlock ([NullAllowed] Action<bool> block);
	}

	// @interface AFNetworking (UIActivityIndicatorView)
	[Category]
	[BaseType (typeof(UIActivityIndicatorView))]
	interface UIActivityIndicatorView_AFNetworking
	{
		// -(void)setAnimatingWithStateOfTask:(NSURLSessionTask * _Nullable)task;
		[Export ("setAnimatingWithStateOfTask:")]
		void SetAnimatingWithStateOfTask ([NullAllowed] NSUrlSessionTask task);
	}

	// @interface AFNetworking (UIButton)
	[Category]
	[BaseType (typeof(UIButton))]
	interface UIButton_AFNetworking
	{
		// +(AFImageDownloader * _Nonnull)sharedImageDownloader;
		// +(void)setSharedImageDownloader:(AFImageDownloader * _Nonnull)imageDownloader;
		[Static]
		[Export ("sharedImageDownloader")]
		[Verify (MethodToProperty)]
		AFImageDownloader SharedImageDownloader { get; set; }

		// -(void)setImageForState:(UIControlState)state withURL:(NSURL * _Nonnull)url;
		[Export ("setImageForState:withURL:")]
		void SetImageForState (UIControlState state, NSUrl url);

		// -(void)setImageForState:(UIControlState)state withURL:(NSURL * _Nonnull)url placeholderImage:(UIImage * _Nullable)placeholderImage;
		[Export ("setImageForState:withURL:placeholderImage:")]
		void SetImageForState (UIControlState state, NSUrl url, [NullAllowed] UIImage placeholderImage);

		// -(void)setImageForState:(UIControlState)state withURLRequest:(NSURLRequest * _Nonnull)urlRequest placeholderImage:(UIImage * _Nullable)placeholderImage success:(void (^ _Nullable)(NSURLRequest * _Nonnull, NSHTTPURLResponse * _Nullable, UIImage * _Nonnull))success failure:(void (^ _Nullable)(NSURLRequest * _Nonnull, NSHTTPURLResponse * _Nullable, NSError * _Nonnull))failure;
		[Export ("setImageForState:withURLRequest:placeholderImage:success:failure:")]
		void SetImageForState (UIControlState state, NSUrlRequest urlRequest, [NullAllowed] UIImage placeholderImage, [NullAllowed] Action<NSURLRequest, NSHTTPURLResponse, UIImage> success, [NullAllowed] Action<NSURLRequest, NSHTTPURLResponse, NSError> failure);

		// -(void)setBackgroundImageForState:(UIControlState)state withURL:(NSURL * _Nonnull)url;
		[Export ("setBackgroundImageForState:withURL:")]
		void SetBackgroundImageForState (UIControlState state, NSUrl url);

		// -(void)setBackgroundImageForState:(UIControlState)state withURL:(NSURL * _Nonnull)url placeholderImage:(UIImage * _Nullable)placeholderImage;
		[Export ("setBackgroundImageForState:withURL:placeholderImage:")]
		void SetBackgroundImageForState (UIControlState state, NSUrl url, [NullAllowed] UIImage placeholderImage);

		// -(void)setBackgroundImageForState:(UIControlState)state withURLRequest:(NSURLRequest * _Nonnull)urlRequest placeholderImage:(UIImage * _Nullable)placeholderImage success:(void (^ _Nullable)(NSURLRequest * _Nonnull, NSHTTPURLResponse * _Nullable, UIImage * _Nonnull))success failure:(void (^ _Nullable)(NSURLRequest * _Nonnull, NSHTTPURLResponse * _Nullable, NSError * _Nonnull))failure;
		[Export ("setBackgroundImageForState:withURLRequest:placeholderImage:success:failure:")]
		void SetBackgroundImageForState (UIControlState state, NSUrlRequest urlRequest, [NullAllowed] UIImage placeholderImage, [NullAllowed] Action<NSURLRequest, NSHTTPURLResponse, UIImage> success, [NullAllowed] Action<NSURLRequest, NSHTTPURLResponse, NSError> failure);

		// -(void)cancelImageDownloadTaskForState:(UIControlState)state;
		[Export ("cancelImageDownloadTaskForState:")]
		void CancelImageDownloadTaskForState (UIControlState state);

		// -(void)cancelBackgroundImageDownloadTaskForState:(UIControlState)state;
		[Export ("cancelBackgroundImageDownloadTaskForState:")]
		void CancelBackgroundImageDownloadTaskForState (UIControlState state);
	}

	// @interface AFNetworking (UIImage)
	[Category]
	[BaseType (typeof(UIImage))]
	interface UIImage_AFNetworking
	{
		// +(UIImage *)safeImageWithData:(NSData *)data;
		[Static]
		[Export ("safeImageWithData:")]
		UIImage SafeImageWithData (NSData data);
	}

	// @interface AFNetworking (UIImageView)
	[Category]
	[BaseType (typeof(UIImageView))]
	interface UIImageView_AFNetworking
	{
		// +(AFImageDownloader * _Nonnull)sharedImageDownloader;
		// +(void)setSharedImageDownloader:(AFImageDownloader * _Nonnull)imageDownloader;
		[Static]
		[Export ("sharedImageDownloader")]
		[Verify (MethodToProperty)]
		AFImageDownloader SharedImageDownloader { get; set; }

		// -(void)setImageWithURL:(NSURL * _Nonnull)url;
		[Export ("setImageWithURL:")]
		void SetImageWithURL (NSUrl url);

		// -(void)setImageWithURL:(NSURL * _Nonnull)url placeholderImage:(UIImage * _Nullable)placeholderImage;
		[Export ("setImageWithURL:placeholderImage:")]
		void SetImageWithURL (NSUrl url, [NullAllowed] UIImage placeholderImage);

		// -(void)setImageWithURLRequest:(NSURLRequest * _Nonnull)urlRequest placeholderImage:(UIImage * _Nullable)placeholderImage success:(void (^ _Nullable)(NSURLRequest * _Nonnull, NSHTTPURLResponse * _Nullable, UIImage * _Nonnull))success failure:(void (^ _Nullable)(NSURLRequest * _Nonnull, NSHTTPURLResponse * _Nullable, NSError * _Nonnull))failure;
		[Export ("setImageWithURLRequest:placeholderImage:success:failure:")]
		void SetImageWithURLRequest (NSUrlRequest urlRequest, [NullAllowed] UIImage placeholderImage, [NullAllowed] Action<NSURLRequest, NSHTTPURLResponse, UIImage> success, [NullAllowed] Action<NSURLRequest, NSHTTPURLResponse, NSError> failure);

		// -(void)cancelImageDownloadTask;
		[Export ("cancelImageDownloadTask")]
		void CancelImageDownloadTask ();
	}

	// @interface AFNetworking (UIRefreshControl)
	[Category]
	[BaseType (typeof(UIRefreshControl))]
	interface UIRefreshControl_AFNetworking
	{
		// -(void)setRefreshingWithStateOfTask:(NSURLSessionTask * _Nonnull)task;
		[Export ("setRefreshingWithStateOfTask:")]
		void SetRefreshingWithStateOfTask (NSUrlSessionTask task);
	}

	// @interface AFNetworking (UIWebView)
	[Category]
	[BaseType (typeof(UIWebView))]
	interface UIWebView_AFNetworking
	{
		// @property (nonatomic, strong) AFHTTPSessionManager * _Nonnull sessionManager;
		[Export ("sessionManager", ArgumentSemantic.Strong)]
		AFHTTPSessionManager SessionManager { get; set; }

		// -(void)loadRequest:(NSURLRequest * _Nonnull)request progress:(NSProgress * _Nullable * _Nullable)progress success:(NSString * _Nonnull (^ _Nullable)(NSHTTPURLResponse * _Nonnull, NSString * _Nonnull))success failure:(void (^ _Nullable)(NSError * _Nonnull))failure;
		[Export ("loadRequest:progress:success:failure:")]
		void LoadRequest (NSUrlRequest request, [NullAllowed] out NSProgress progress, [NullAllowed] Func<NSHTTPURLResponse, NSString, NSString> success, [NullAllowed] Action<NSError> failure);

		// -(void)loadRequest:(NSURLRequest * _Nonnull)request MIMEType:(NSString * _Nullable)MIMEType textEncodingName:(NSString * _Nullable)textEncodingName progress:(NSProgress * _Nullable * _Nullable)progress success:(NSData * _Nonnull (^ _Nullable)(NSHTTPURLResponse * _Nonnull, NSData * _Nonnull))success failure:(void (^ _Nullable)(NSError * _Nonnull))failure;
		[Export ("loadRequest:MIMEType:textEncodingName:progress:success:failure:")]
		void LoadRequest (NSUrlRequest request, [NullAllowed] string MIMEType, [NullAllowed] string textEncodingName, [NullAllowed] out NSProgress progress, [NullAllowed] Func<NSHTTPURLResponse, NSData, NSData> success, [NullAllowed] Action<NSError> failure);
	}

	// @interface AFNetworking (UIProgressView)
	[Category]
	[BaseType (typeof(UIProgressView))]
	interface UIProgressView_AFNetworking
	{
		// -(void)setProgressWithUploadProgressOfTask:(NSURLSessionUploadTask * _Nonnull)task animated:(BOOL)animated;
		[Export ("setProgressWithUploadProgressOfTask:animated:")]
		void SetProgressWithUploadProgressOfTask (NSUrlSessionUploadTask task, bool animated);

		// -(void)setProgressWithDownloadProgressOfTask:(NSURLSessionDownloadTask * _Nonnull)task animated:(BOOL)animated;
		[Export ("setProgressWithDownloadProgressOfTask:animated:")]
		void SetProgressWithDownloadProgressOfTask (NSUrlSessionDownloadTask task, bool animated);
	}

	[Static]
	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern double AFNetworkingVersionNumber;
		[Field ("AFNetworkingVersionNumber", "__Internal")]
		double AFNetworkingVersionNumber { get; }

		// extern const unsigned char [] AFNetworkingVersionString;
		[Field ("AFNetworkingVersionString", "__Internal")]
		byte[] AFNetworkingVersionString { get; }
	}
}
