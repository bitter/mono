﻿#if SECURITY_DEP
#if MONO_SECURITY_ALIAS
extern alias MonoSecurity;
#endif

using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Security.Authentication;

#if MONO_SECURITY_ALIAS
using MonoSecurity::Mono.Security.Interface;
#else
using Mono.Security.Interface;
#endif

using MNS = Mono.Net.Security;

namespace Mono.Mbedtls
{
	public class MbedtlsProvider : MonoTlsProvider
	{
		static readonly Guid id = new Guid ("d7ad9d8d-5df9-4455-a34a-70fae79471fb");

		public override Guid ID {
			get { return id; }
		}
		public override string Name {
			get { return "mbedtls"; }
		}

		public override bool SupportsSslStream {
			get { return true; }
		}

		public override bool SupportsMonoExtensions {
			get { return true; }
		}

		public override bool SupportsConnectionInfo {
			get { return true; }
		}

		public override SslProtocols SupportedProtocols {
			get { return SslProtocols.Tls12 | SslProtocols.Tls11 | SslProtocols.Tls; }
		}


		public override IMonoSslStream CreateSslStream (
			Stream innerStream, bool leaveInnerStreamOpen,
			MonoTlsSettings settings = null)
		{
			return new MbedtlsStream (innerStream, leaveInnerStreamOpen, settings, this);
		}

		internal override bool ValidateCertificate (
			ICertificateValidator2 validator, string targetHost, bool serverMode,
			X509CertificateCollection certificates, bool wantsChain, ref X509Chain chain,
			ref MonoSslPolicyErrors errors, ref int status11)
		{

			if (wantsChain)
				chain = MNS.SystemCertificateValidator.CreateX509Chain (certificates);

			if (certificates == null || certificates.Count == 0) {
				errors |= MonoSslPolicyErrors.RemoteCertificateNotAvailable;
				return false;
			}

			// fixup targetHost name
			if (!string.IsNullOrEmpty (targetHost)) {
				var pos = targetHost.IndexOf (':');
				if (pos > 0)
					targetHost = targetHost.Substring (0, pos);
			}

			// convert (back) to native
			Mbedtls.mbedtls_x509_crt crt_ca, trust_ca;
			Mbedtls.mbedtls_x509_crt_init (out crt_ca);
			Mbedtls.mbedtls_x509_crt_init (out trust_ca);

			foreach (X509Certificate certificate in certificates)
				CertificateHelper.AddToChain(ref crt_ca, certificate);

			CertificateHelper.AddSystemCertificates(ref trust_ca);

			uint flags = 0;
			int result = Mbedtls.mbedtls_x509_crt_verify(ref crt_ca, ref trust_ca, IntPtr.Zero, targetHost, ref flags, IntPtr.Zero, IntPtr.Zero);
			Console.Error.WriteLine("result {0:X4}", -result);
			Console.Error.WriteLine("flags {0:X4}", flags);

			Mbedtls.mbedtls_x509_crt_free (ref crt_ca);
			Mbedtls.mbedtls_x509_crt_free (ref trust_ca);

			return result == 0 && flags == 0;
		}
	}
}
#endif