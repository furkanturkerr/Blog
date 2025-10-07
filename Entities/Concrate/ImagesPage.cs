namespace Entities.Concrate
{
    public class ImagesPage
    {
        public int Id { get; set; }

        
        public string FileName { get; set; }       
        public string FilePath { get; set; }       
        public string FileType { get; set; }       
        public long FileSize { get; set; }         
        public DateTime UploadDate { get; set; }  
        
        // SEO alanları
        public string AltText { get; set; }        
        public string Title { get; set; }          
        public string SeoSlug { get; set; }        
        public string Description { get; set; }    
        public string Keywords { get; set; }       

        // İsteğe bağlı
        public string UploadedBy { get; set; }     
        public bool IsActive { get; set; }         
    }
}