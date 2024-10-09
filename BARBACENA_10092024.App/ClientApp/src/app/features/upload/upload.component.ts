import { Component } from '@angular/core';
import { VideoService } from '../../services/video.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.css']
})
export class UploadComponent {
  uploadForm: FormGroup;
  selectedFile: File | null = null;
  categories: string[] = [
    'Education',
    'Entertainment',
    'Lifestyle',
    'Technology',
    'Gaming',
    'Health & Fitness',
    'Science & Nature',
    'Arts & Crafts',
    'News & Politics',
    'Sports'
  ];

  constructor(private videoService: VideoService, private router: Router) {
    this.uploadForm = new FormGroup({
      title: new FormControl('', Validators.required),
      description: new FormControl('', [Validators.required, Validators.maxLength(160)]),
      category: new FormControl('', Validators.required),
      file: new FormControl(null, Validators.required),
    });
  }

  onFileSelected(event: any) {
    const input = event.target as HTMLInputElement;

    if (input.files && input.files.length > 0) {
      const file = input.files[0];

      // Check file extension
      const validExtensions = ['mp4', 'avi', 'mov'];
      const fileExtension = file.name.split('.').pop()?.toLowerCase();

      if (fileExtension && validExtensions.includes(fileExtension)) {
        this.selectedFile = file;
        this.uploadForm.value.file = file;
        if (this.isFileSizeExceedsLimit(file.size)) {
          alert('File size should be up to 100 mb only.');
        }
      } else {
        alert('Please select a valid video file (MP4, AVI, MOV).');
        input.value = '';
      }
    }
  }

  isFileSizeExceedsLimit(bytes: number): boolean {
    var fileSizeInMb = bytes / (1024 * 1024)
    return fileSizeInMb > 100;
  }

  onSubmit() {
    if (this.uploadForm.errors || !this.selectedFile) {
      return;
    }

    const formData = new FormData();
    formData.append('title', this.uploadForm.get('title')?.value);
    formData.append('description', this.uploadForm.get('description')?.value);
    formData.append('categories', this.uploadForm.get('category')?.value);
    formData.append('file', this.selectedFile);
    this.videoService.uploadVideo(formData).subscribe(
      (response) => {
        if (response.success) {
          this.router.navigate(['/']);
        }
        else {
          alert(response.message);
        }
      },
      (error) => {
        alert(error);
      }
    );
  }
}
