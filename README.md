# KindlegenBulkConverter
Bulk convert files to .mobi using kindlegen


1. Build exe for the console application.
2. Download kindlegen from amazon at https://www.amazon.com/gp/feature.html?ie=UTF8&docId=1000765211
3. Drop the kindlegen.exe file into the console application's directory
4. Run KindlegenBulkConverter.exe with arguments

## Arguments

KindlegenBulkConverter supports wildcards and direct file paths. It will also convert any book formats supported by kindlegen 
(see their documentation)

### Examples

KindlegenBulkConverter.exe c:/path/book.epub
KindlegenBulkConverter.exe c:/path/book.epub c:/path/book2.epub
KindlegenBulkConverter.exe "c:/path with spaces/book.epub"
KindlegenBulkConverter.exe "c:/path with spaces/*.epub"
KindlegenBulkConverter.exe c:/path/*.epub
KindlegenBulkConverter.exe c:/path/*.epub c:/path/*.html
KindlegenBulkConverter.exe c:/path/book1.epub c:/path/*.pdf
