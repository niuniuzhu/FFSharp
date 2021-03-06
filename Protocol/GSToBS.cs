// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: GSToBS.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace GSToBS {

  /// <summary>Holder for reflection information generated from GSToBS.proto</summary>
  public static partial class GSToBSReflection {

    #region Descriptor
    /// <summary>File descriptor for GSToBS.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static GSToBSReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CgxHU1RvQlMucHJvdG8SBkdTVG9CUyJNCgtBc2tSZWdpc3RlchIcCgVtZ3Np",
            "ZBgBIAEoDjINLkdTVG9CUy5Nc2dJRBIMCgRnc2lkGAIgASgFEhIKCmxpc3Rl",
            "bnBvcnQYAyABKAUiSgoSUmVwb3J0QWxsQ2xpZW50SW5mEhwKBW1zZ2lkGAEg",
            "ASgOMg0uR1NUb0JTLk1zZ0lEEhYKDnRva2VubGlzdF9zaXplGAIgASgNKsAB",
            "CgVNc2dJRBIKCgZ1bmtub3cQABIaChRlTXNnVG9CU0Zyb21HU19CZWdpbhCA",
            "gAISIAoaZU1zZ1RvQlNGcm9tR1NfQXNrUmVnaXN0ZXIQgYACEigKImVNc2dU",
            "b0JTRnJvbUdTX1JlcG9ydEFsbENsaWVudEluZm8QgoACEikKI2VNc2dUb0JT",
            "RnJvbUdTX09uZVVzZXJMb2dpblRva2VuUmV0EIOAAhIYChJlTXNnVG9CU0Zy",
            "b21HU19FbmQQoIACYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(new[] {typeof(global::GSToBS.MsgID), }, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::GSToBS.AskRegister), global::GSToBS.AskRegister.Parser, new[]{ "Mgsid", "Gsid", "Listenport" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::GSToBS.ReportAllClientInf), global::GSToBS.ReportAllClientInf.Parser, new[]{ "Msgid", "TokenlistSize" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Enums
  public enum MsgID {
    [pbr::OriginalName("unknow")] Unknow = 0,
    [pbr::OriginalName("eMsgToBSFromGS_Begin")] EMsgToBsfromGsBegin = 32768,
    [pbr::OriginalName("eMsgToBSFromGS_AskRegister")] EMsgToBsfromGsAskRegister = 32769,
    [pbr::OriginalName("eMsgToBSFromGS_ReportAllClientInfo")] EMsgToBsfromGsReportAllClientInfo = 32770,
    [pbr::OriginalName("eMsgToBSFromGS_OneUserLoginTokenRet")] EMsgToBsfromGsOneUserLoginTokenRet = 32771,
    [pbr::OriginalName("eMsgToBSFromGS_End")] EMsgToBsfromGsEnd = 32800,
  }

  #endregion

  #region Messages
  public sealed partial class AskRegister : pb::IMessage<AskRegister> {
    private static readonly pb::MessageParser<AskRegister> _parser = new pb::MessageParser<AskRegister>(() => new AskRegister());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<AskRegister> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::GSToBS.GSToBSReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AskRegister() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AskRegister(AskRegister other) : this() {
      mgsid_ = other.mgsid_;
      gsid_ = other.gsid_;
      listenport_ = other.listenport_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AskRegister Clone() {
      return new AskRegister(this);
    }

    /// <summary>Field number for the "mgsid" field.</summary>
    public const int MgsidFieldNumber = 1;
    private global::GSToBS.MsgID mgsid_ = 0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::GSToBS.MsgID Mgsid {
      get { return mgsid_; }
      set {
        mgsid_ = value;
      }
    }

    /// <summary>Field number for the "gsid" field.</summary>
    public const int GsidFieldNumber = 2;
    private int gsid_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Gsid {
      get { return gsid_; }
      set {
        gsid_ = value;
      }
    }

    /// <summary>Field number for the "listenport" field.</summary>
    public const int ListenportFieldNumber = 3;
    private int listenport_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Listenport {
      get { return listenport_; }
      set {
        listenport_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as AskRegister);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(AskRegister other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Mgsid != other.Mgsid) return false;
      if (Gsid != other.Gsid) return false;
      if (Listenport != other.Listenport) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Mgsid != 0) hash ^= Mgsid.GetHashCode();
      if (Gsid != 0) hash ^= Gsid.GetHashCode();
      if (Listenport != 0) hash ^= Listenport.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Mgsid != 0) {
        output.WriteRawTag(8);
        output.WriteEnum((int) Mgsid);
      }
      if (Gsid != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(Gsid);
      }
      if (Listenport != 0) {
        output.WriteRawTag(24);
        output.WriteInt32(Listenport);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Mgsid != 0) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Mgsid);
      }
      if (Gsid != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Gsid);
      }
      if (Listenport != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Listenport);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(AskRegister other) {
      if (other == null) {
        return;
      }
      if (other.Mgsid != 0) {
        Mgsid = other.Mgsid;
      }
      if (other.Gsid != 0) {
        Gsid = other.Gsid;
      }
      if (other.Listenport != 0) {
        Listenport = other.Listenport;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            mgsid_ = (global::GSToBS.MsgID) input.ReadEnum();
            break;
          }
          case 16: {
            Gsid = input.ReadInt32();
            break;
          }
          case 24: {
            Listenport = input.ReadInt32();
            break;
          }
        }
      }
    }

  }

  public sealed partial class ReportAllClientInf : pb::IMessage<ReportAllClientInf> {
    private static readonly pb::MessageParser<ReportAllClientInf> _parser = new pb::MessageParser<ReportAllClientInf>(() => new ReportAllClientInf());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<ReportAllClientInf> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::GSToBS.GSToBSReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ReportAllClientInf() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ReportAllClientInf(ReportAllClientInf other) : this() {
      msgid_ = other.msgid_;
      tokenlistSize_ = other.tokenlistSize_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ReportAllClientInf Clone() {
      return new ReportAllClientInf(this);
    }

    /// <summary>Field number for the "msgid" field.</summary>
    public const int MsgidFieldNumber = 1;
    private global::GSToBS.MsgID msgid_ = 0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::GSToBS.MsgID Msgid {
      get { return msgid_; }
      set {
        msgid_ = value;
      }
    }

    /// <summary>Field number for the "tokenlist_size" field.</summary>
    public const int TokenlistSizeFieldNumber = 2;
    private uint tokenlistSize_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint TokenlistSize {
      get { return tokenlistSize_; }
      set {
        tokenlistSize_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as ReportAllClientInf);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(ReportAllClientInf other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Msgid != other.Msgid) return false;
      if (TokenlistSize != other.TokenlistSize) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Msgid != 0) hash ^= Msgid.GetHashCode();
      if (TokenlistSize != 0) hash ^= TokenlistSize.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Msgid != 0) {
        output.WriteRawTag(8);
        output.WriteEnum((int) Msgid);
      }
      if (TokenlistSize != 0) {
        output.WriteRawTag(16);
        output.WriteUInt32(TokenlistSize);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Msgid != 0) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Msgid);
      }
      if (TokenlistSize != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(TokenlistSize);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(ReportAllClientInf other) {
      if (other == null) {
        return;
      }
      if (other.Msgid != 0) {
        Msgid = other.Msgid;
      }
      if (other.TokenlistSize != 0) {
        TokenlistSize = other.TokenlistSize;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            msgid_ = (global::GSToBS.MsgID) input.ReadEnum();
            break;
          }
          case 16: {
            TokenlistSize = input.ReadUInt32();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
