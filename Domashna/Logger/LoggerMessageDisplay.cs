using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domashna.Logger
{
    public class LoggerMessageDisplay
    {
        // Movie Messages

        public const string MoviesListed = "All movies listed successfully!";

        public const string NoMoviesInDB = "There is no movies in the DB!";

        public const string MovieFoundDisplayDetails = "Movie was found in the DB, show the details of the movie";

        public const string NoMovieFound = "There is no Movie found in the DB!";

        public const string MovieCreated = "New movie is created in the DB";

        public const string MovieCreatedNotFound = "The movie is not created";

        public const string MovieNotCreatedModelStateInvalid = "New movie is NOT created in the DB, ModelState is not valid";

        public const string MovieEdited = "Movie is edited successfully";

        public const string MovieEditedError = "Movie has not been edited successfully";

        public const string MovieEditNotFound = "Movie for editting is not found in the DB";

        public const string MovieEditErrorModelStateInvalid = "Movie is not edited, ModelState is not valid";

        public const string MovieDeleted = "Movie is deleted successfully";

        public const string MovieDeletedError = "Movie is NOT deleted, error happend in process of deletion";

        public const string MovieDeleteErrorModelStateInvalid = "Movie is not deleted, ModelState is not valid";

        // Director Messages

        public const string DirectorsListed = "All Directors listed successfully!";

        public const string NoDirectorsInDB = "There is no Directors in the DB!";

        public const string DirectorFoundDisplayDetails = "Director was found in the DB, show the details of the Director";

        public const string NoDirectorFound = "This is no Director found in the DB!";

        public const string DirectorCreated = "New Director is created in the DB";

        public const string DirectorCreatedNotFound = "The director is not created";

        public const string DirectorNotCreatedModelStateInvalid = "New Director is NOT created in the DB, ModelState is not valid";

        public const string DirectorEdited = "Director is edited successfully";

        public const string DirectorEditNotFound = "Director for editting is not found in the DB";

        public const string DirectorEditErrorModelStateInvalid = "Director is not edited, ModelState is not valid";

        public const string DirectorDeleted = "Director is deleted successfully";

        public const string DirectorDeletedError = "Director is NOT deleted, error happend in process of deletion";

        public const string DirectorDeleteErrorModelStateInvalid = "Director is not deleted, ModelState is not valid";

        // Genre Messages

        public const string GenresListed = "All Genres listed successfully!";

        public const string NoGenresInDB = "There is no Genres in the DB!";

        public const string GenreFoundDisplayDetails = "Genre was found in the DB, show the details of the Genre";

        public const string NoGenreFound = "This is no Genre found in the DB!";

        public const string GenreCreated = "New Genre is created in the DB";

        public const string GenreCreatedNotFound = "The genre is not created";

        public const string GenreNotCreatedModelStateInvalid = "New Genre is NOT created in the DB, ModelState is not valid";

        public const string GenreEdited = "Genre is edited successfully";

        public const string GenreEditedError = "Genre is not edited successfully";

        public const string GenreEditErrorModelStateInvalid = "Genre is not edited, ModelState is not valid";

        public const string GenreDeleted = "Genre is deleted successfully";

        public const string GenreDeletedError = "Genre is NOT deleted, error happend in process of deletion";

        public const string GenreDeleteErrorModelStateInvalid = "Movie is not deleted, ModelState is not valid";

        // User Messages

        public const string UsersListed = "All users listed successfully!";

        public const string NoUsersInDB = "There is no user in the DB!";

        public const string UserFoundDisplayDetails = "User was found in the DB, show the details of the user";

        public const string NoUserFound = "This is no user found in the DB!";

        public const string UserCreated = "New user is created in the DB";

        public const string UserNotCreatedModelStateInvalid = "New user is NOT created in the DB, ModelState is not valid";

        public const string UserEdited = "User is edited successfully";

        public const string UserEditErrorModelStateInvalid = "User is not edited, ModelState is not valid";

        public const string UserDeleted = "User is deleted successfully";

        public const string UserDeletedError = "User is NOT deleted, error happend in process of deletion";

        public const string UserDeleteErrorModelStateInvalid = "User is not deleted, ModelState is not valid";

        // Listed Movie Messages

        public const string ListMovieListed = "All Listed movies listed successfully!";

        public const string NoListedMovieInDB = "There is no listed movies in the DB!";

        public const string ListedMovieFoundDisplayDetails = "Listed movie was found in the DB, show the details of the movie";

        public const string NoListedsMovieFound = "There is no Movie found in the DB!";

        public const string ListedMovieCreated = "New listed movie is created in the DB";

        public const string ListedMovieCreatedNotFound = "The listed movie is not created";

        public const string ListedMovieNotCreatedModelStateInvalid = "Listed movie is NOT created in the DB, ModelState is not valid";

        public const string ListedMovieEdited = "Listed movie is edited successfully";

        public const string ListedMovieEditedError = "Listed movie has not been edited successfully";

        public const string ListedMovieEditNotFound = "Listed movie for editting is not found in the DB";

        public const string ListedMovieEditErrorModelStateInvalid = "Listed movie is not edited, ModelState is not valid";

        public const string ListedMovieDeleted = "Listed movie is deleted successfully";

        public const string ListedMovieDeletedError = "Listed movie is NOT deleted, error happend in process of deletion";

        public const string ListedMovieDeleteErrorModelStateInvalid = "Listed movie is not deleted, ModelState is not valid";

        // Rented Movie Messages

        public const string RentMovieListed = "All rented movies listed successfully!";

        public const string NoRentedMovieInDB = "There is no rented movies in the DB!";

        public const string RentedMovieFoundDisplayDetails = "Rented movie was found in the DB, show the details of the movie";

        public const string NoRentedsMovieFound = "There is no Movie found in the DB!";

        public const string RentedMovieCreated = "New rented movie is created in the DB";

        public const string RentedMovieCreatedNotFound = "The rented movie is not created";

        public const string RentedMovieNotCreatedModelStateInvalid = "Rented movie is NOT created in the DB, ModelState is not valid";

        public const string RentedMovieEditErrorModelStateInvalid = "Rented movie is not edited, ModelState is not valid";

        public const string RentedMovieDeleted = "Rented movie is deleted successfully";

        public const string RentedMovieDeletedError = "Rented movie is NOT deleted, error happend in process of deletion";

        public const string RentedMovieDeleteErrorModelStateInvalid = "Rented movie is not deleted, ModelState is not valid";

    }
}
