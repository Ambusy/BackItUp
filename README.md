# BackItUp
Utility to backup disk(s) and/or folders maintaining the folder structure equal in original and backup.

Create (or generate) a script naming each map to be backupped by inclusion or exclusion.
- exclusion copies everything in a map that is not expressly excluded (so a newly created folder is automatically backupped)
- inclusion copies only the named folders or files, new ones are not backupped. 
If a folder is a candidate to be copied, you can backup the files in it again by inclusion or exclusion.
Files in the backup can be overwritten is the original was modified, or incrementally added to the backup in a folder with the filename as name and date-signed names for the datafiles.

An initial script can be generated by the utility, based on the exclusion principle, which includes all by default.
A list of folders and files eligible for backup is shown. 
The user can point at folders or files to be excluded
This exclusion is then added to the script.

You may check for files or folders that are on the backup, but deleted in the original. You can decide for each folder or file to delete the version on the backup, or leave it there.

Open the HELP.HTML in the bin/release folder to view the documentation. Written in VBasic, Visual Studio 2019
