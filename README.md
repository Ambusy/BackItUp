# BackItUp
Utility to backup disk(s) maintaining the folder structure equal in original and backup.

Create (or generate) a script naming each map to be backed up by inclusion or exclusion.
- exclusion copies everything in a map that is not expressly excluded (so a newly created folder is automatically backed up)
- inclusion copies only the named folders or files, newly created ones are not backupped. 
If a folder is a candidate to be copied, you can backup the contained maps or files once again by inclusion or exclusion.
Files in the backup can be overwritten is the original was modified, or incrementally added to the backup in a folder with the filename as name and date-signed names for the datafiles, to keep all versions of the file.

An initial script can be generated by the utility, based on the exclusion principle, which includes all by default.
A list of folders and files eligible for backup is shown. 
The user can point at folders or files to be excluded.
This exclusion is then added to the script.

You may check for files or folders that are in the backup, but deleted in the original. You can decide for each desired folder or file to delete the version in the backup.

Open the HELP.HTML in the bin/release folder to view the documentation. Written in VBasic, Visual Studio 2019
