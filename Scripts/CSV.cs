namespace DSATools
{
    public class CSV
    {
        public string[] Headers { get; set; } = Array.Empty<string>();
        public List<string[]> Rows { get; set; } = new();
        
        public CSV Filtered(List<string> HeaderWhitelist)
        {
            // Find the indexes of headers that are in the whitelist
            var allowedIndexes = Headers
                .Select((header, index) => new { header, index })
                .Where(x => HeaderWhitelist.Contains(x.header))
                .Select(x => x.index)
                .ToList();

            // Filter headers
            var filteredHeaders = allowedIndexes.Select(index => Headers[index]).ToArray();

            // Filter rows
            var filteredRows = Rows
                .Select(row => allowedIndexes.Select(index => row[index]).ToArray())
                .ToList();

            // Return the filtered CSV data
            return new CSV
            {
                Headers = filteredHeaders,
                Rows = filteredRows
            };
        }
        
    }
}