﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'This class was auto-generated by the StronglyTypedResourceBuilder
    'class via a tool like ResGen or Visual Studio.
    'To add or remove a member, edit your .ResX file then rerun ResGen
    'with the /str option, or rebuild your VS project.
    '''<summary>
    '''  A strongly-typed resource class, for looking up localized strings, etc.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Class Strings
        
        Private Shared resourceMan As Global.System.Resources.ResourceManager
        
        Private Shared resourceCulture As Global.System.Globalization.CultureInfo
        
        <Global.System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")>  _
        Friend Sub New()
            MyBase.New
        End Sub
        
        '''<summary>
        '''  Returns the cached ResourceManager instance used by this class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Shared ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("APTV2.Strings", GetType(Strings).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  Overrides the current thread's CurrentUICulture property for all
        '''  resource lookups using this strongly typed resource class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Shared Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Installing app on the device(make sure device is plugged in, otherwise it will not output anything).
        '''</summary>
        Friend Shared ReadOnly Property Home_btnGappsInstall_Click_Installing_app_on_the_device_make_sure_device_is_plugged_in__otherwise_it_will_not_output_anything_() As String
            Get
                Return ResourceManager.GetString("Home_btnGappsInstall_Click_Installing_app_on_the_device_make_sure_device_is_plugg"& _ 
                        "ed_in__otherwise_it_will_not_output_anything_", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to You have not entered a unlock key.
        '''Some devices might not require it.
        '''Continue?.
        '''</summary>
        Friend Shared ReadOnly Property Home_btnLockBootloader_Click_() As String
            Get
                Return ResourceManager.GetString("Home_btnLockBootloader_Click_", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Relocking bootloader: (make sure device is plugged, otherwise it will not output anything).
        '''</summary>
        Friend Shared ReadOnly Property Home_btnLockBootloader_Click_Relocking_bootloader___make_sure_device_is_plugged__otherwise_it_will_not_output_anything_() As String
            Get
                Return ResourceManager.GetString("Home_btnLockBootloader_Click_Relocking_bootloader___make_sure_device_is_plugged__"& _ 
                        "otherwise_it_will_not_output_anything_", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to You have not entered a unlock key.
        '''Some devices might not require it.
        '''Continue?.
        '''</summary>
        Friend Shared ReadOnly Property Home_btnUnlockBootloader_Click_() As String
            Get
                Return ResourceManager.GetString("Home_btnUnlockBootloader_Click_", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Proceed.
        '''</summary>
        Friend Shared ReadOnly Property Home_btnUnlockBootloader_Click_Proceed() As String
            Get
                Return ResourceManager.GetString("Home_btnUnlockBootloader_Click_Proceed", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Rebooting device.
        '''</summary>
        Friend Shared ReadOnly Property Home_btnUnlockBootloader_Click_Rebooting_device() As String
            Get
                Return ResourceManager.GetString("Home_btnUnlockBootloader_Click_Rebooting_device", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Unlocking bootloader: (make sure device is plugged, otherwise it will not output anything).
        '''</summary>
        Friend Shared ReadOnly Property Home_btnUnlockBootloader_Click_Unlocking_bootloader() As String
            Get
                Return ResourceManager.GetString("Home_btnUnlockBootloader_Click_Unlocking_bootloader", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Download completed!.
        '''</summary>
        Friend Shared ReadOnly Property Home_Completed_Download_completed_() As String
            Get
                Return ResourceManager.GetString("Home_Completed_Download_completed_", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Download has been canceled..
        '''</summary>
        Friend Shared ReadOnly Property Home_Completed_Download_has_been_canceled_() As String
            Get
                Return ResourceManager.GetString("Home_Completed_Download_has_been_canceled_", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to File not found!.
        '''</summary>
        Friend Shared ReadOnly Property Home_getInfoXMLInner_Not_Found() As String
            Get
                Return ResourceManager.GetString("Home_getInfoXMLInner_Not_Found", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to File not found or file corrupt.
        '''</summary>
        Friend Shared ReadOnly Property Home_readXML_File_not_found_or_file_corrupt() As String
            Get
                Return ResourceManager.GetString("Home_readXML_File_not_found_or_file_corrupt", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Rebooting to bootloader.
        '''</summary>
        Friend Shared ReadOnly Property Rebooting_to_bootloader() As String
            Get
                Return ResourceManager.GetString("Rebooting_to_bootloader", resourceCulture)
            End Get
        End Property
    End Class
End Namespace
