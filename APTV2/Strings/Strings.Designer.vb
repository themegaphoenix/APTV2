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
        Friend Shared ReadOnly Property Home_btnFlashMagiskManager_Click_Installing_app_on_the_device_make_sure_device_is_plugged_in__otherwise_it_will_not_output_anything_() As String
            Get
                Return ResourceManager.GetString("Home_btnFlashMagiskManager_Click_Installing_app_on_the_device_make_sure_device_is"& _ 
                        "_plugged_in__otherwise_it_will_not_output_anything_", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Open the Magisk Manager Application.
        '''</summary>
        Friend Shared ReadOnly Property Home_btnFlashMagiskManager_Click_Open_the_Magisk_Manager_Application() As String
            Get
                Return ResourceManager.GetString("Home_btnFlashMagiskManager_Click_Open_the_Magisk_Manager_Application", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Is the phone in fastboot mode? If not please boot into it first and then press yes..
        '''</summary>
        Friend Shared ReadOnly Property Home_btnFlashUnbr_Click_Please_boot_the_phone_into_fastboot_mode() As String
            Get
                Return ResourceManager.GetString("Home_btnFlashUnbr_Click_Please_boot_the_phone_into_fastboot_mode", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Reboot into fastboot mode.
        '''</summary>
        Friend Shared ReadOnly Property Home_btnFlashUnbr_Click_Reboot_into_fastboot_mode() As String
            Get
                Return ResourceManager.GetString("Home_btnFlashUnbr_Click_Reboot_into_fastboot_mode", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Rebooting to fastboot.
        '''</summary>
        Friend Shared ReadOnly Property Home_btnFlashUnbr_Click_Rebooting_to_fastboot() As String
            Get
                Return ResourceManager.GetString("Home_btnFlashUnbr_Click_Rebooting_to_fastboot", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Power on your Honor 7 Holding all three buttons (VOL+, VOL- and Power) and it will begin flashing.
        '''</summary>
        Friend Shared ReadOnly Property Home_btnFlashUnbrRecovery_Click_Power_on_your_Honor_7_Holding_all_three_buttons__VOL___VOL__and_Power__and_it_will_begin_flashing() As String
            Get
                Return ResourceManager.GetString("Home_btnFlashUnbrRecovery_Click_Power_on_your_Honor_7_Holding_all_three_buttons__"& _ 
                        "VOL___VOL__and_Power__and_it_will_begin_flashing", resourceCulture)
            End Get
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
        '''  Looks up a localized string similar to Root the device?.
        '''</summary>
        Friend Shared ReadOnly Property Home_btnUnlockBootloader_Click_Root_the_device_() As String
            Get
                Return ResourceManager.GetString("Home_btnUnlockBootloader_Click_Root_the_device_", resourceCulture)
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
        '''  Looks up a localized string similar to Would you like to flash a custom recovery like TWRP?.
        '''</summary>
        Friend Shared ReadOnly Property Home_btnUnlockBootloader_Click_Would_you_like_to_flash_a_custom_recovery_like_TWRP_() As String
            Get
                Return ResourceManager.GetString("Home_btnUnlockBootloader_Click_Would_you_like_to_flash_a_custom_recovery_like_TWR"& _ 
                        "P_", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to New version of the XML (data) file found. Download now?.
        '''</summary>
        Friend Shared ReadOnly Property Home_CheckXMLUpdates_New_version_of_the_XML__data__file_found__Download_now_() As String
            Get
                Return ResourceManager.GetString("Home_CheckXMLUpdates_New_version_of_the_XML__data__file_found__Download_now_", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Update.
        '''</summary>
        Friend Shared ReadOnly Property Home_CheckXMLUpdates_Update() As String
            Get
                Return ResourceManager.GetString("Home_CheckXMLUpdates_Update", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Update Complete.
        '''</summary>
        Friend Shared ReadOnly Property Home_CheckXMLUpdates_Update_Complete() As String
            Get
                Return ResourceManager.GetString("Home_CheckXMLUpdates_Update_Complete", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Update Found.
        '''</summary>
        Friend Shared ReadOnly Property Home_CheckXMLUpdates_Update_Found() As String
            Get
                Return ResourceManager.GetString("Home_CheckXMLUpdates_Update_Found", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to You have the latest version.
        '''</summary>
        Friend Shared ReadOnly Property Home_CheckXMLUpdates_You_have_the_latest_version() As String
            Get
                Return ResourceManager.GetString("Home_CheckXMLUpdates_You_have_the_latest_version", resourceCulture)
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
        '''  Looks up a localized string similar to  already exists..
        '''</summary>
        Friend Shared ReadOnly Property Home_DownloadFileAsync_File_already_exists() As String
            Get
                Return ResourceManager.GetString("Home_DownloadFileAsync_File_already_exists", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to  does not exist. Starting download..
        '''</summary>
        Friend Shared ReadOnly Property Home_DownloadFileAsync_File_does_not_exist__Starting_Download_() As String
            Get
                Return ResourceManager.GetString("Home_DownloadFileAsync_File_does_not_exist__Starting_Download_", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Link not found.
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
        '''  Looks up a localized string similar to File does not contains valid information..
        '''</summary>
        Friend Shared ReadOnly Property Home_ReloadInfo_File_does_not_contains_invalid_information() As String
            Get
                Return ResourceManager.GetString("Home_ReloadInfo_File_does_not_contains_invalid_information", resourceCulture)
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
