#if SECURITY_DEP
#if MONO_SECURITY_ALIAS
extern alias MonoSecurity;
#endif

using System;
using System.Runtime.InteropServices;

namespace Mono.Mbed
{
	[StructLayout (LayoutKind.Sequential)]
	struct size_t
	{
		IntPtr m_Value;
		size_t (IntPtr val) { m_Value = val; }

		public static implicit operator int (size_t val) { return val.m_Value.ToInt32 (); }
		public static implicit operator long (size_t val) { return val.m_Value.ToInt64 (); }
		public static implicit operator size_t (int val) { return new size_t (new IntPtr (val)); }
		public static implicit operator size_t (long val) { return new size_t (new IntPtr (val)); }

		public override string ToString ()
		{
			return String.Format ("{0}", (long)m_Value);
		}
	}

	class MonoMbedTlsAPI
	{
		internal const int MBEDTLS_SSL_HELLO_REQUEST = 0x00;
		internal const int MBEDTLS_SSL_CLIENT_HELLO = 0x01;
		internal const int MBEDTLS_SSL_SERVER_HELLO = 0x02;
		internal const int MBEDTLS_SSL_SERVER_CERTIFICATE = 0x03;
		internal const int MBEDTLS_SSL_SERVER_KEY_EXCHANGE = 0x04;
		internal const int MBEDTLS_SSL_CERTIFICATE_REQUEST = 0x05;
		internal const int MBEDTLS_SSL_SERVER_HELLO_DONE = 0x06;
		internal const int MBEDTLS_SSL_CLIENT_CERTIFICATE = 0x07;
		internal const int MBEDTLS_SSL_CLIENT_KEY_EXCHANGE = 0x08;
		internal const int MBEDTLS_SSL_CERTIFICATE_VERIFY = 0x09;
		internal const int MBEDTLS_SSL_CLIENT_CHANGE_CIPHER_SPEC = 0x0A;
		internal const int MBEDTLS_SSL_CLIENT_FINISHED = 0x0B;
		internal const int MBEDTLS_SSL_SERVER_CHANGE_CIPHER_SPEC = 0x0C;
		internal const int MBEDTLS_SSL_SERVER_FINISHED = 0x0D;
		internal const int MBEDTLS_SSL_FLUSH_BUFFERS = 0x0E;
		internal const int MBEDTLS_SSL_HANDSHAKE_WRAPUP = 0x0F;
		internal const int MBEDTLS_SSL_HANDSHAKE_OVER = 0x10;
		internal const int MBEDTLS_SSL_SERVER_NEW_SESSION_TICKET = 0x11;
		internal const int MBEDTLS_SSL_SERVER_HELLO_VERIFY_REQUEST_SENT = 0x12;

		internal const uint MBEDTLS_SSL_IS_CLIENT = 0;
		internal const uint MBEDTLS_SSL_IS_SERVER = 1;
		internal const uint MBEDTLS_SSL_TRANSPORT_STREAM = 0;
		internal const uint MBEDTLS_SSL_TRANSPORT_DATAGRAM = 1;
		internal const uint MBEDTLS_SSL_PRESET_DEFAULT = 0;
		internal const uint MBEDTLS_SSL_PRESET_SUITEB = 2;

		internal const uint MBEDTLS_SSL_VERIFY_NONE = 0;
		internal const uint MBEDTLS_SSL_VERIFY_OPTIONAL = 1;
		internal const uint MBEDTLS_SSL_VERIFY_REQUIRED = 2;
		internal const uint MBEDTLS_SSL_VERIFY_UNSET = 3; /* Used only for sni_authmode */

		/*
		 * SSL NET Error codes
		 */
		internal const int MBEDTLS_ERR_NET_SOCKET_FAILED = -0x0042;  /**< Failed to open a socket. */
		internal const int MBEDTLS_ERR_NET_CONNECT_FAILED = -0x0044;  /**< The connection to the given server / port failed. */
		internal const int MBEDTLS_ERR_NET_BIND_FAILED = -0x0046;  /**< Binding of the socket failed. */
		internal const int MBEDTLS_ERR_NET_LISTEN_FAILED = -0x0048;  /**< Could not listen on the socket. */
		internal const int MBEDTLS_ERR_NET_ACCEPT_FAILED = -0x004A;  /**< Could not accept the incoming connection. */
		internal const int MBEDTLS_ERR_NET_RECV_FAILED = -0x004C;  /**< Reading information from the socket failed. */
		internal const int MBEDTLS_ERR_NET_SEND_FAILED = -0x004E;  /**< Sending information through the socket failed. */
		internal const int MBEDTLS_ERR_NET_CONN_RESET = -0x0050;  /**< Connection was reset by peer. */
		internal const int MBEDTLS_ERR_NET_UNKNOWN_HOST = -0x0052;  /**< Failed to get an IP address for the given hostname. */
		internal const int MBEDTLS_ERR_NET_BUFFER_TOO_SMALL = -0x0043;  /**< Buffer is too small to hold the data. */
		internal const int MBEDTLS_ERR_NET_INVALID_CONTEXT = -0x0045;  /**< The context is invalid, eg because it was free()ed. */

		/*
		 * SSL Error codes
		 */
		internal const int MBEDTLS_ERR_SSL_FEATURE_UNAVAILABLE = -0x7080;  /**< The requested feature is not available. */
		internal const int MBEDTLS_ERR_SSL_BAD_INPUT_DATA = -0x7100;  /**< Bad input parameters to function. */
		internal const int MBEDTLS_ERR_SSL_INVALID_MAC = -0x7180;  /**< Verification of the message MAC failed. */
		internal const int MBEDTLS_ERR_SSL_INVALID_RECORD = -0x7200;  /**< An invalid SSL record was received. */
		internal const int MBEDTLS_ERR_SSL_CONN_EOF = -0x7280;  /**< The connection indicated an EOF. */
		internal const int MBEDTLS_ERR_SSL_UNKNOWN_CIPHER = -0x7300;  /**< An unknown cipher was received. */
		internal const int MBEDTLS_ERR_SSL_NO_CIPHER_CHOSEN = -0x7380;  /**< The server has no ciphersuites in common with the client. */
		internal const int MBEDTLS_ERR_SSL_NO_RNG = -0x7400;  /**< No RNG was provided to the SSL module. */
		internal const int MBEDTLS_ERR_SSL_NO_CLIENT_CERTIFICATE = -0x7480;  /**< No client certification received from the client, but required by the authentication mode. */
		internal const int MBEDTLS_ERR_SSL_CERTIFICATE_TOO_LARGE = -0x7500;  /**< Our own certificate(s) is/are too large to send in an SSL message. */
		internal const int MBEDTLS_ERR_SSL_CERTIFICATE_REQUIRED = -0x7580;  /**< The own certificate is not set, but needed by the server. */
		internal const int MBEDTLS_ERR_SSL_PRIVATE_KEY_REQUIRED = -0x7600;  /**< The own private key or pre-shared key is not set, but needed. */
		internal const int MBEDTLS_ERR_SSL_CA_CHAIN_REQUIRED = -0x7680;  /**< No CA Chain is set, but required to operate. */
		internal const int MBEDTLS_ERR_SSL_UNEXPECTED_MESSAGE = -0x7700;  /**< An unexpected message was received from our peer. */
		internal const int MBEDTLS_ERR_SSL_FATAL_ALERT_MESSAGE = -0x7780;  /**< A fatal alert message was received from our peer. */
		internal const int MBEDTLS_ERR_SSL_PEER_VERIFY_FAILED = -0x7800;  /**< Verification of our peer failed. */
		internal const int MBEDTLS_ERR_SSL_PEER_CLOSE_NOTIFY = -0x7880;  /**< The peer notified us that the connection is going to be closed. */
		internal const int MBEDTLS_ERR_SSL_BAD_HS_CLIENT_HELLO = -0x7900;  /**< Processing of the ClientHello handshake message failed. */
		internal const int MBEDTLS_ERR_SSL_BAD_HS_SERVER_HELLO = -0x7980;  /**< Processing of the ServerHello handshake message failed. */
		internal const int MBEDTLS_ERR_SSL_BAD_HS_CERTIFICATE = -0x7A00;  /**< Processing of the Certificate handshake message failed. */
		internal const int MBEDTLS_ERR_SSL_BAD_HS_CERTIFICATE_REQUEST = -0x7A80;  /**< Processing of the CertificateRequest handshake message failed. */
		internal const int MBEDTLS_ERR_SSL_BAD_HS_SERVER_KEY_EXCHANGE = -0x7B00;  /**< Processing of the ServerKeyExchange handshake message failed. */
		internal const int MBEDTLS_ERR_SSL_BAD_HS_SERVER_HELLO_DONE = -0x7B80;  /**< Processing of the ServerHelloDone handshake message failed. */
		internal const int MBEDTLS_ERR_SSL_BAD_HS_CLIENT_KEY_EXCHANGE = -0x7C00;  /**< Processing of the ClientKeyExchange handshake message failed. */
		internal const int MBEDTLS_ERR_SSL_BAD_HS_CLIENT_KEY_EXCHANGE_RP = -0x7C80;  /**< Processing of the ClientKeyExchange handshake message failed in DHM / ECDH Read Public. */
		internal const int MBEDTLS_ERR_SSL_BAD_HS_CLIENT_KEY_EXCHANGE_CS = -0x7D00;  /**< Processing of the ClientKeyExchange handshake message failed in DHM / ECDH Calculate Secret. */
		internal const int MBEDTLS_ERR_SSL_BAD_HS_CERTIFICATE_VERIFY = -0x7D80;  /**< Processing of the CertificateVerify handshake message failed. */
		internal const int MBEDTLS_ERR_SSL_BAD_HS_CHANGE_CIPHER_SPEC = -0x7E00;  /**< Processing of the ChangeCipherSpec handshake message failed. */
		internal const int MBEDTLS_ERR_SSL_BAD_HS_FINISHED = -0x7E80;  /**< Processing of the Finished handshake message failed. */
		internal const int MBEDTLS_ERR_SSL_ALLOC_FAILED = -0x7F00;  /**< Memory allocation failed */
		internal const int MBEDTLS_ERR_SSL_HW_ACCEL_FAILED = -0x7F80;  /**< Hardware acceleration function returned with error */
		internal const int MBEDTLS_ERR_SSL_HW_ACCEL_FALLTHROUGH = -0x6F80;  /**< Hardware acceleration function skipped / left alone data */
		internal const int MBEDTLS_ERR_SSL_COMPRESSION_FAILED = -0x6F00;  /**< Processing of the compression / decompression failed */
		internal const int MBEDTLS_ERR_SSL_BAD_HS_PROTOCOL_VERSION = -0x6E80;  /**< Handshake protocol not within min/max boundaries */
		internal const int MBEDTLS_ERR_SSL_BAD_HS_NEW_SESSION_TICKET = -0x6E00;  /**< Processing of the NewSessionTicket handshake message failed. */
		internal const int MBEDTLS_ERR_SSL_SESSION_TICKET_EXPIRED = -0x6D80;  /**< Session ticket has expired. */
		internal const int MBEDTLS_ERR_SSL_PK_TYPE_MISMATCH = -0x6D00;  /**< Public key type mismatch (eg, asked for RSA key exchange and presented EC key) */
		internal const int MBEDTLS_ERR_SSL_UNKNOWN_IDENTITY = -0x6C80;  /**< Unknown identity received (eg, PSK identity) */
		internal const int MBEDTLS_ERR_SSL_INTERNAL_ERROR = -0x6C00;  /**< Internal error (eg, unexpected failure in lower-level module) */
		internal const int MBEDTLS_ERR_SSL_COUNTER_WRAPPING = -0x6B80;  /**< A counter would wrap (eg, too many messages exchanged). */
		internal const int MBEDTLS_ERR_SSL_WAITING_SERVER_HELLO_RENEGO = -0x6B00;  /**< Unexpected message at ServerHello in renegotiation. */
		internal const int MBEDTLS_ERR_SSL_HELLO_VERIFY_REQUIRED = -0x6A80;  /**< DTLS client must retry for hello verification */
		internal const int MBEDTLS_ERR_SSL_BUFFER_TOO_SMALL = -0x6A00;  /**< A buffer is too small to receive or write a message */
		internal const int MBEDTLS_ERR_SSL_NO_USABLE_CIPHERSUITE = -0x6980;  /**< None of the common ciphersuites is usable (eg, no suitable certificate, see debug messages). */
		internal const int MBEDTLS_ERR_SSL_WANT_READ = -0x6900;  /**< Connection requires a read call. */
		internal const int MBEDTLS_ERR_SSL_WANT_WRITE = -0x6880;  /**< Connection requires a write call. */
		internal const int MBEDTLS_ERR_SSL_TIMEOUT = -0x6800;  /**< The operation timed out. */
		internal const int MBEDTLS_ERR_SSL_CLIENT_RECONNECT = -0x6780;  /**< The client initiated a reconnect from the same port. */
		internal const int MBEDTLS_ERR_SSL_UNEXPECTED_RECORD = -0x6700;  /**< Record header looks valid but is not expected. */
		internal const int MBEDTLS_ERR_SSL_NON_FATAL = -0x6680;  /**< The alert message received indicates a non-fatal error. */
		internal const int MBEDTLS_ERR_SSL_INVALID_VERIFY_HASH = -0x6600;  /**< Couldn't set the hash for verifying CertificateVerify */

		/**
		 * X509 Error codes
		 */
		internal const int MBEDTLS_ERR_X509_FEATURE_UNAVAILABLE            =  -0x2080;  /**< Unavailable feature, e.g. RSA hashing/encryption combination. */
		internal const int MBEDTLS_ERR_X509_UNKNOWN_OID                    =  -0x2100;  /**< Requested OID is unknown. */
		internal const int MBEDTLS_ERR_X509_INVALID_FORMAT                 =  -0x2180;  /**< The CRT/CRL/CSR format is invalid, e.g. different type expected. */
		internal const int MBEDTLS_ERR_X509_INVALID_VERSION                =  -0x2200;  /**< The CRT/CRL/CSR version element is invalid. */
		internal const int MBEDTLS_ERR_X509_INVALID_SERIAL                 =  -0x2280;  /**< The serial tag or value is invalid. */
		internal const int MBEDTLS_ERR_X509_INVALID_ALG                    =  -0x2300;  /**< The algorithm tag or value is invalid. */
		internal const int MBEDTLS_ERR_X509_INVALID_NAME                   =  -0x2380;  /**< The name tag or value is invalid. */
		internal const int MBEDTLS_ERR_X509_INVALID_DATE                   =  -0x2400;  /**< The date tag or value is invalid. */
		internal const int MBEDTLS_ERR_X509_INVALID_SIGNATURE              =  -0x2480;  /**< The signature tag or value invalid. */
		internal const int MBEDTLS_ERR_X509_INVALID_EXTENSIONS             =  -0x2500;  /**< The extension tag or value is invalid. */
		internal const int MBEDTLS_ERR_X509_UNKNOWN_VERSION                =  -0x2580;  /**< CRT/CRL/CSR has an unsupported version number. */
		internal const int MBEDTLS_ERR_X509_UNKNOWN_SIG_ALG                =  -0x2600;  /**< Signature algorithm (oid) is unsupported. */
		internal const int MBEDTLS_ERR_X509_SIG_MISMATCH                   =  -0x2680;  /**< Signature algorithms do not match. (see \c ::mbedtls_x509_crt sig_oid) */
		internal const int MBEDTLS_ERR_X509_CERT_VERIFY_FAILED             =  -0x2700;  /**< Certificate verification failed, e.g. CRL, CA or signature check failed. */
		internal const int MBEDTLS_ERR_X509_CERT_UNKNOWN_FORMAT            =  -0x2780;  /**< Format not recognized as DER or PEM. */
		internal const int MBEDTLS_ERR_X509_BAD_INPUT_DATA                 =  -0x2800;  /**< Input invalid. */
		internal const int MBEDTLS_ERR_X509_ALLOC_FAILED                   =  -0x2880;  /**< Allocation of memory failed. */
		internal const int MBEDTLS_ERR_X509_FILE_IO_ERROR                  =  -0x2900;  /**< Read/write of file failed. */
		internal const int MBEDTLS_ERR_X509_BUFFER_TOO_SMALL               =  -0x2980;  /**< Destination buffer is too small. */

		/**
		 * X509 Verification codes
		 */
		internal const uint MBEDTLS_X509_BADCERT_EXPIRED       =     0x01;  /**< The certificate validity has expired. */
		internal const uint MBEDTLS_X509_BADCERT_REVOKED       =     0x02;  /**< The certificate has been revoked (is on a CRL). */
		internal const uint MBEDTLS_X509_BADCERT_CN_MISMATCH   =     0x04;  /**< The certificate Common Name (CN) does not match with the expected CN. */
		internal const uint MBEDTLS_X509_BADCERT_NOT_TRUSTED   =     0x08;  /**< The certificate is not correctly signed by the trusted CA. */
		internal const uint MBEDTLS_X509_BADCRL_NOT_TRUSTED    =     0x10;  /**< The CRL is not correctly signed by the trusted CA. */
		internal const uint MBEDTLS_X509_BADCRL_EXPIRED        =     0x20;  /**< The CRL is expired. */
		internal const uint MBEDTLS_X509_BADCERT_MISSING       =     0x40;  /**< Certificate was missing. */
		internal const uint MBEDTLS_X509_BADCERT_SKIP_VERIFY   =     0x80;  /**< Certificate verification was skipped. */
		internal const uint MBEDTLS_X509_BADCERT_OTHER         =   0x0100;  /**< Other reason (can be used by verify callback) */
		internal const uint MBEDTLS_X509_BADCERT_FUTURE        =   0x0200;  /**< The certificate validity starts in the future. */
		internal const uint MBEDTLS_X509_BADCRL_FUTURE         =   0x0400;  /**< The CRL is from the future */
		internal const uint MBEDTLS_X509_BADCERT_KEY_USAGE     =   0x0800;  /**< Usage does not match the keyUsage extension. */
		internal const uint MBEDTLS_X509_BADCERT_EXT_KEY_USAGE =   0x1000;  /**< Usage does not match the extendedKeyUsage extension. */
		internal const uint MBEDTLS_X509_BADCERT_NS_CERT_TYPE  =   0x2000;  /**< Usage does not match the nsCertType extension. */
		internal const uint MBEDTLS_X509_BADCERT_BAD_MD        =   0x4000;  /**< The certificate is signed with an unacceptable hash. */
		internal const uint MBEDTLS_X509_BADCERT_BAD_PK        =   0x8000;  /**< The certificate is signed with an unacceptable PK alg (eg RSA vs ECDSA). */
		internal const uint MBEDTLS_X509_BADCERT_BAD_KEY       = 0x010000;  /**< The certificate is signed with an unacceptable key (eg bad curve, RSA too short). */
		internal const uint MBEDTLS_X509_BADCRL_BAD_MD         = 0x020000;  /**< The CRL is signed with an unacceptable hash. */
		internal const uint MBEDTLS_X509_BADCRL_BAD_PK         = 0x040000;  /**< The CRL is signed with an unacceptable PK alg (eg RSA vs ECDSA). */
		internal const uint MBEDTLS_X509_BADCRL_BAD_KEY        = 0x080000;  /**< The CRL is signed with an unacceptable key (eg bad curve, RSA too short). */

		// [TODO] Fix sizes
		[StructLayout (LayoutKind.Sequential)]
		unsafe internal struct mbedtls_entropy_context
		{
			public fixed byte buffer [4096];
		}

		[StructLayout (LayoutKind.Sequential)]
		unsafe internal struct mbedtls_ssl_config
		{
			public fixed byte buffer [4096];
		}

		[StructLayout (LayoutKind.Sequential)]
		unsafe internal struct mbedtls_ssl_context
		{
			private IntPtr conf;
			internal int state;
			internal int renego_status;
			internal int renego_records_seen;
			internal int major_ver;
			internal int minor_ver;
			internal uint badmac_seen;
			public fixed byte buffer [4096];
		}

		[StructLayout (LayoutKind.Sequential)]
		unsafe internal struct mbedtls_ctr_drbg_context
		{
			public fixed byte buffer [4096];
		}

		[StructLayout (LayoutKind.Sequential)]
		internal struct mbedtls_x509_buf /*mbedtls_asn1_buf*/
		{
			internal int tag;
			internal size_t len;
			internal IntPtr data;
		}

		[StructLayout (LayoutKind.Sequential)]
		internal struct mbedtls_x509_name /*mbedtls_asn1_named_data*/
		{
			internal mbedtls_x509_buf oid;
			internal mbedtls_x509_buf val;
			internal IntPtr next;
			internal byte next_merged;
		}

		[StructLayout (LayoutKind.Sequential)]
		internal struct mbedtls_x509_time
		{
			internal int year, mon, day;
			internal int hour, min, sec;
		}

		[StructLayout (LayoutKind.Sequential)]
		internal struct mbedtls_x509_sequence /*mbedtls_asn1_sequence*/
		{
			internal mbedtls_x509_buf buf;
			internal IntPtr next;
		}

		[StructLayout (LayoutKind.Sequential)]
		unsafe internal struct mbedtls_x509_crt
		{
			internal mbedtls_x509_buf raw;
			internal mbedtls_x509_buf tbs;
			internal int version;
			internal mbedtls_x509_buf serial;
			internal mbedtls_x509_buf sig_oid;
			internal mbedtls_x509_buf issuer_raw;
			internal mbedtls_x509_buf subject_raw;
			internal mbedtls_x509_name issuer;
			internal mbedtls_x509_name subject;
			internal mbedtls_x509_time valid_from;
			internal mbedtls_x509_time valid_to;
			internal mbedtls_pk_context pk;
			internal mbedtls_x509_buf issuer_id;
			internal mbedtls_x509_buf subject_id;
			internal mbedtls_x509_buf v3_ext;
			internal mbedtls_x509_sequence subject_alt_names;
			internal int ext_types;
			internal int ca_istrue;
			internal int max_pathlen;
			internal uint key_usage;
			internal mbedtls_x509_sequence ext_key_usage;
			internal byte ns_cert_type;
			internal mbedtls_x509_buf sig;
			internal uint sig_md; /*mbedtls_md_type_t*/
			internal uint sig_pk; /*mbedtls_pk_type_t*/
			internal IntPtr sig_opts;
			internal IntPtr next;
		}

		[StructLayout (LayoutKind.Sequential)]
		unsafe internal struct mbedtls_pk_context
		{
			IntPtr pk_info;
			IntPtr pk_ctx;
		}

		[DllImport ("mbedtls")]
		extern internal static void mbedtls_entropy_init (out mbedtls_entropy_context ctx);

		[DllImport ("mbedtls")]
		extern internal static void mbedtls_entropy_free (ref mbedtls_entropy_context ctx);

		[DllImport ("mbedtls")]
		extern internal static void mbedtls_ssl_init (out mbedtls_ssl_context ctx);

		[DllImport ("mbedtls")]
		extern internal static void mbedtls_ssl_free (ref mbedtls_ssl_context ctx);

		[DllImport ("mbedtls")]
		extern internal static void mbedtls_ssl_config_init (out mbedtls_ssl_config ctx);

		[DllImport ("mbedtls")]
		extern internal static void mbedtls_ssl_config_free (ref mbedtls_ssl_config ctx);

		[DllImport ("mbedtls")]
		extern internal static void mbedtls_ctr_drbg_init (out mbedtls_ctr_drbg_context ctx);

		[DllImport ("mbedtls")]
		extern internal static void mbedtls_ctr_drbg_free (ref mbedtls_ctr_drbg_context ctx);

		[DllImport ("mbedtls")]
		extern internal static int mbedtls_ctr_drbg_random (IntPtr p_rng, IntPtr output, size_t len);

		[DllImport ("mbedtls")]
		extern internal static int mbedtls_ssl_config_defaults (ref mbedtls_ssl_config conf, uint endpoint, uint transport, uint preset);

		[DllImport ("mbedtls")]
		extern internal static int mbedtls_ssl_conf_rng (ref mbedtls_ssl_config conf, mbedtls_ctr_drbg_random_t f_rng, ref mbedtls_ctr_drbg_context p_rng);

		[DllImport ("mbedtls")]
		extern internal static int mbedtls_ctr_drbg_seed (ref mbedtls_ctr_drbg_context ctx, mbedtls_entropy_t f_entropy, ref mbedtls_entropy_context p_entropy, IntPtr input, size_t len);

		[DllImport ("mbedtls")]
		extern internal static void mbedtls_ssl_set_bio (ref mbedtls_ssl_context ssl, IntPtr bio, mbedtls_ssl_send_t f_send, mbedtls_ssl_recv_t f_recv, mbedtls_ssl_recv_timeout_t f_recv_timeout);

		[DllImport ("mbedtls")]
		extern internal static int mbedtls_entropy_func (IntPtr data, IntPtr output, size_t len);

		[DllImport ("mbedtls")]
		extern internal static int mbedtls_ssl_setup (ref mbedtls_ssl_context ssl, ref mbedtls_ssl_config conf);

		[DllImport ("mbedtls")]
		extern internal static int mbedtls_ssl_handshake (ref mbedtls_ssl_context ssl);

		[DllImport ("mbedtls")]
		extern internal static int mbedtls_ssl_handshake_step (ref mbedtls_ssl_context ssl);

		[DllImport ("mbedtls")]
		extern internal static int mbedtls_ssl_set_hostname (ref mbedtls_ssl_context ssl, IntPtr hostname);

		[DllImport ("mbedtls")]
		extern internal static void mbedtls_ssl_conf_dbg (ref mbedtls_ssl_config conf, mbedtls_ssl_dbg_t f_dbg, IntPtr p_dbg);

		[DllImport ("mbedtls")]
		extern internal static void mbedtls_debug_set_threshold (int level);

		[DllImport ("mbedtls")]
		extern internal static void mbedtls_ssl_conf_authmode (ref mbedtls_ssl_config conf, uint authmode);

		[DllImport ("mbedtls")]
		extern internal static int mbedtls_ssl_read (ref mbedtls_ssl_context ssl, IntPtr buf, int len);

		[DllImport ("mbedtls")]
		extern internal static int mbedtls_ssl_write (ref mbedtls_ssl_context ssl, IntPtr buf, size_t len);

		[DllImport ("mbedtls")]
		extern internal static void mbedtls_strerror (int err, IntPtr buf, size_t len);

		[DllImport ("mbedtls")]
		extern internal static IntPtr mbedtls_ssl_get_peer_cert (ref mbedtls_ssl_context ssl);

		[DllImport ("mbedtls")]
		extern internal static IntPtr mbedtls_ssl_get_ciphersuite (ref mbedtls_ssl_context ssl);

		[DllImport ("mbedtls")]
		extern internal static int mbedtls_ssl_get_ciphersuite_id (IntPtr ciphersuite_name);

		[DllImport ("mbedtls")]
		extern internal static int mbedtls_ssl_conf_own_cert (ref mbedtls_ssl_config conf, ref mbedtls_x509_crt own_cert, ref mbedtls_pk_context pk_key);

		[DllImport ("mbedtls")]
		extern internal static void mbedtls_ssl_conf_ca_chain (ref mbedtls_ssl_config conf, ref mbedtls_x509_crt ca_chain, IntPtr ca_crl);

		[DllImport ("mbedtls")]
		extern internal static void mbedtls_ssl_conf_verify (ref mbedtls_ssl_config conf, mbedtls_verify_t f_vrfy, IntPtr p_vrfy);

		// --------------------------------
		// X.509
		// --------------------------------
		[DllImport ("mbedtls")]
		extern internal static void mbedtls_x509_crt_init (out mbedtls_x509_crt crt);

		[DllImport ("mbedtls")]
		extern internal static void mbedtls_x509_crt_free (ref mbedtls_x509_crt crt);

		[DllImport ("mbedtls")]
		extern internal static int mbedtls_x509_crt_parse (ref mbedtls_x509_crt chain, IntPtr cert, size_t len);

		// --------------------------------
		// Private/Public Key
		// --------------------------------
		[DllImport ("mbedtls")]
		extern internal static void mbedtls_pk_init (out mbedtls_pk_context ctx);

		[DllImport ("mbedtls")]
		extern internal static void mbedtls_pk_free (ref mbedtls_pk_context crt);

		[DllImport ("mbedtls")]
		extern internal static int mbedtls_pk_parse_key (ref mbedtls_pk_context ctx, IntPtr key, size_t keylen, IntPtr pwd, size_t pwdlen);

		[DllImport ("mbedtls")]
		extern internal static int mbedtls_x509_crt_verify(ref mbedtls_x509_crt crt, ref mbedtls_x509_crt trust_ca, IntPtr ca_crl, [MarshalAs(UnmanagedType.LPStr)]string cn, ref uint flags, IntPtr ignore, IntPtr ignore2);

		// --------------------------------
		// delegates
		// --------------------------------
		internal delegate int mbedtls_entropy_t (IntPtr p_entropy, IntPtr output, size_t len);
		internal delegate int mbedtls_ctr_drbg_random_t (IntPtr p_rng, IntPtr output, size_t len);
		internal delegate int mbedtls_ssl_send_t (IntPtr stream, IntPtr buffer, size_t len);
		internal delegate int mbedtls_ssl_recv_t (IntPtr stream, IntPtr buffer, size_t len);
		internal delegate int mbedtls_ssl_recv_timeout_t (IntPtr stream, IntPtr buffer, size_t len, uint timeout);
		internal delegate int mbedtls_verify_t (IntPtr p_vrfy, ref mbedtls_x509_crt crt, int depth, ref uint flags);
		internal delegate void mbedtls_ssl_dbg_t (IntPtr p_debug, int level, IntPtr file, int line, IntPtr message);

	}

}
#endif