import { Component, Input, OnInit } from '@angular/core';
import { Movie } from '../_models/movie';
import { Rating } from '../_models/rating';
import { MoviesService } from '../_services/movies.service';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from "ngx-spinner";
import { ServiceResponse } from '../_models/serviceResponse';

@Component({
  selector: 'app-movie-card',
  templateUrl: './movie-card.component.html',
  styleUrls: ['./movie-card.component.css']
})
export class MovieCardComponent implements OnInit {
  @Input() movie!: Movie;
  rate = 0;
  max = 5;
  isReadonly = false;


  constructor(private moviesService: MoviesService, private toastr: ToastrService,
    private spinner: NgxSpinnerService) {
  }

  
  ngOnInit(): void {
    this.moviesService.getCurrentAvgRating(this.movie.id).subscribe(
      (response) => { 
      let serviceResponse: ServiceResponse<number>;
      serviceResponse = response;
      this.rate = serviceResponse.data;
    });
  }

  getRating($event: any) {
    var newRating: Rating = { value: this.rate, movieId: this.movie.id };
    this.movie.ratings.push(newRating);
    var newAvg: any;
    this.moviesService.addRating(newRating).subscribe(
      response => {
        this.toastr.success(
          'Thank you for leaving a rating', '',
          {
            positionClass: 'toast-bottom-center',
            tapToDismiss: true,
            closeButton: true
          });
        
        this.spinner.show();

        setTimeout(() => {
          this.spinner.hide();
          location.reload();
        }, 1300);
      }
    );

  }

}
