using System;
using System.Runtime.InteropServices;
using AFNetworking;
using Foundation;
using ObjCRuntime;

namespace AFNetworking
{
	// static class CFunctions
	// {
	// 	// extern NSString * _Nonnull AFPercentEscapedStringFromString (NSString * _Nonnull string);
	// 	[DllImport ("__Internal")]
	// 	[Verify (PlatformInvoke)]
	// 	static extern NSString AFPercentEscapedStringFromString (NSString @string);

	// 	// extern NSString * _Nonnull AFQueryStringFromParameters (NSDictionary * _Nonnull parameters);
	// 	[DllImport ("__Internal")]
	// 	[Verify (PlatformInvoke)]
	// 	static extern NSString AFQueryStringFromParameters (NSDictionary parameters);

	// 	// extern NSString * _Nonnull AFStringFromNetworkReachabilityStatus (AFNetworkReachabilityStatus status);
	// 	[DllImport ("__Internal")]
	// 	[Verify (PlatformInvoke)]
	// 	static extern NSString AFStringFromNetworkReachabilityStatus (AFNetworkReachabilityStatus status);
	// }

	[Native]
	public enum AFHTTPRequestQueryStringSerializationStyle : ulong
	{
		AFHTTPRequestQueryStringDefaultStyle = 0
	}

	[Native]
	public enum AFSSLPinningMode : ulong
	{
		None,
		PublicKey,
		Certificate
	}

	[Native]
	public enum AFNetworkReachabilityStatus : long
	{
		Unknown = -1,
		NotReachable = 0,
		ReachableViaWWAN = 1,
		ReachableViaWiFi = 2
	}

	[Native]
	public enum AFImageDownloadPrioritization : long
	{
		Fifo,
		Lifo
	}
}
