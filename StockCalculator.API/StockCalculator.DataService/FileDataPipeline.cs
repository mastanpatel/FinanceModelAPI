using System;
using System.Collections.Generic;
using System.Text;

namespace StockCalculator.DataService
{
    class FileDataPipeline
    {
        //step 1 - fetch the details of file to download
        //step 2 - download the file at specified path

        //difficulty in download file for now we download it manuaaly


        //step 3 - extract hte file if zip file
        //step 4 - remove the folder from file and delete the zip file after extraction
        //step 5 - update the flag isDownload to true in db
        //step 6 - process the file one by one and update the flag processed as true
        //step 7 - if any error log the error and move the file to error specified folder and update the flag is error as true and is process as false

    }
}
