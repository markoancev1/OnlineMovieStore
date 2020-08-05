using Domashna.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domashna.Data
{
    public class DataContext : IdentityDbContext<IdentityUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Photo> Photos { get; set; }
     //   public DbSet<User> User { get; set; }
        public DbSet<ListingMovie> ListingMovies { get; set; }
        public DbSet<RentingMovie> RentingMovies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            const string ADMIN_ID = "b4280b6a-0613-4cbd-a9e6-f1701e926e73";
            const string ROLE_ID = ADMIN_ID;
            const string password = "admin123abc";
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = ROLE_ID,
                    Name = "admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = "b4280b6a-0613-4cbd-a9e6-f1701e926e74",
                    Name = "editor",
                    NormalizedName = "EDITOR"
                },
                new IdentityRole
                {
                    Id = "b4280b6a-0613-4cbd-a9e6-f1701e926e75",
                    Name = "guest",
                    NormalizedName = "GUEST"
                }
              );

            var hasher = new PasswordHasher<IdentityUser>(); builder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = ADMIN_ID,
                UserName = "admin@onlinemoviestore.com",
                NormalizedUserName = "ADMIN@ONLINEMOVIESTORE.COM",
                Email = "admin@onlinemoviestore.com",
                NormalizedEmail = "ADMIN@ONLINEMOVIESTORE.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, password),
                SecurityStamp = string.Empty,
                ConcurrencyStamp = "c8554266-b401-4519-9aeb-a9283053fc58"
            }); builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });
            builder.Entity<Genre>().HasData(
                new Genre
                {
                    Id = 1,
                    Name = "Fiction"
                },
                new Genre
                {
                    Id = 2,
                    Name = "Action"
                },
                new Genre
                {
                    Id = 3,
                    Name = "Crime"
                },
                new Genre
                {
                    Id = 4,
                    Name = "Adventure"
                },
                new Genre
                {
                    Id = 5,
                    Name = "Drama"
                },
                new Genre
                {
                    Id = 6,
                    Name = "Fantasy"
                },
                new Genre
                {
                    Id = 7,
                    Name = "Thrillers"
                },
                new Genre
                {
                    Id = 8,
                    Name = "General"
                },
                new Genre
                {
                    Id = 9,
                    Name = "Horror"
                },
                new Genre
                {
                    Id = 10,
                    Name = "Sci-fi"
                });

            builder.Entity<Director>().HasData(

                new Director

                {

                    Id = 1,

                    Name = "Steven Spielberg",

                    Country = "USA",

                    Popularity = true

                },

                new Director

                {

                    Id = 2,

                    Name = "Martin Scorsese",

                    Country = "USA",

                    Popularity = false
                },

                new Director

                {

                    Id = 3,

                    Name = "Alfred Hitchcock ",

                    Country = "England",

                    Popularity = true

                },

                new Director

                {

                    Id = 4,

                    Name = "Stanley Kubrick",

                    Country = "USA",

                    Popularity = false
                },

                new Director

                {

                    Id = 5,

                    Name = "Quentin Tarantino",

                    Country = "USA",

                    Popularity = false

                },

                new Director

                {

                    Id = 6,

                    Name = "Krsto Papic",

                    Country = "Yugoslavia",

                    Popularity = true

                },

                new Director

                {

                    Id = 7,

                    Name = "Orson Welles",

                    Country = "USA",

                    Popularity = true

                },

                new Director

                {

                    Id = 8,

                    Name = "Francis Ford Coppola",

                    Country = "USA",

                    Popularity = false

                },

                new Director

                {

                    Id = 9,

                    Name = "Ridley Scott",

                    Country = "England",

                    Popularity = true

                },

                new Director

                {

                    Id = 10,

                    Name = "Akira Kurosawa",

                    Country = "Japan",

                    Popularity = false
                }
           );

            builder.Entity<Movie>().HasData(

                new Movie
                {
                    Id = 1,
                    Title = "Jurassic Park",
                    DirectorID = 1,
                    DirectorName = "Steven Spielberg",
                    GenreID = 6,
                    GenreName = "Fantasy",
                    YearOfRelease = new DateTime(1993, 6, 9, 1, 0, 0),
                    IMBDScore = 8.1,
                    Price = 9.99,
                    Description = "Jurassic Park is a 1993 American science fiction adventure film directed by Steven Spielberg and produced by Kathleen Kennedy and Gerald R." +
                    "Molen. It is the first installment in the Jurassic Park franchise, and is based on the 1990 novel of the same name by Michael Crichton and a screenplay written by" +
                    "Crichton and David Koepp. The film is set on the fictional island of Isla Nublar, located off Central America's Pacific Coast near Costa Rica." +
                    "There, wealthy businessman John Hammond and a team of genetic scientists have created a wildlife park of de-extinct dinosaurs." +
                    "When industrial sabotage leads to a catastrophic shutdown of the park's power facilities and security precautions, a small group of visitors and" +
                    "Hammond's grandchildren struggle to survive and escape the perilous island.",
                    Language = "English",
                    Country = "USA",
                    PhotoURL = "Jurassic_Park_poster.jpg"

                },
                new Movie
                {
                    Id = 2,
                    Title = "Saving Private Ryan",
                    DirectorID = 1,
                    DirectorName = "Steven Spielberg",
                    GenreID = 2,
                    GenreName = "Action",
                    YearOfRelease = new DateTime(1981, 7, 24, 1, 0, 0),
                    IMBDScore = 8.1,
                    Price = 14.99,
                    Description = "Opening with the Allied invasion of Normandy on 6 June 1944, members of the 2nd Ranger Battalion under Cpt." +
                    "Miller fight ashore to secure a beachhead. Amidst the fighting, two brothers are killed in action. Earlier in New Guinea, a third brother is KIA." +
                    "Their mother, Mrs. Ryan, is to receive all three of the grave telegrams on the same day. The United States Army Chief of Staff, George C. Marshall," +
                    "is given an opportunity to alleviate some of her grief when he learns of a fourth brother, Private James Ryan, and decides to send out 8 men" +
                    "(Cpt. Miller and select members from 2nd Rangers) to find him and bring him back home to his mother... Written by J.Zelman",
                    Language = "English",
                    Country = "USA",
                    PhotoURL = "Saving_Private_Ryan_poster.jpg"

                }, new Movie
                {
                    Id = 3,
                    Title = "Poltergeist",
                    DirectorID = 1,
                    DirectorName = "Steven Spielberg",
                    GenreID = 9,
                    GenreName = "Horror",
                    YearOfRelease = new DateTime(1982, 6, 4, 1, 0, 0),
                    IMBDScore = 7.3,
                    Price = 14.99,
                    Description = "A young family are visited by ghosts in their home. At first the ghosts appear friendly, moving objects around the house to the amusement of everyone," +
                    "then they turn nasty and start to terrorise the family before they kidnap the youngest daughter. Written by Rob Hartill",
                    Language = "English",
                    Country = "USA",
                    PhotoURL = "Poltergeist_(1982).png"

                }, new Movie
                {
                    Id = 4,
                    Title = "Goodfellas",
                    DirectorID = 2,
                    DirectorName = "Martin Scorsese",
                    GenreID = 3,
                    GenreName = "Crime",
                    YearOfRelease = new DateTime(1990, 5, 21, 1, 0, 0),
                    IMBDScore = 8.7,
                    Price = 9.99,
                    Description = "JHenry Hill might be a small time gangster, who may have taken part in a robbery with Jimmy Conway and Tommy De Vito," +
                    "two other gangsters who might have set their sights a bit higher. His two partners could kill off everyone else involved in the robbery," +
                    "and slowly start to think about climbing up through the hierarchy of the Mob. Henry, however, might be badly affected by his partners' success," +
                    "but will he consider stooping low enough to bring about the downfall of Jimmy and Tommy? Written by Colin Tinto",
                    Language = "English",
                    Country = "USA",
                    PhotoURL = "Goodfellas.jpg"

                }, new Movie
                {
                    Id = 5,
                    Title = "Psycho",
                    DirectorID = 3,
                    DirectorName = "Alfred Hitchcock",
                    GenreID = 7,
                    GenreName = "Thriller",
                    YearOfRelease = new DateTime(1960, 9, 8, 1, 0, 0),
                    IMBDScore = 8.5,
                    Price = 4.99,
                    Description = "Phoenix office worker Marion Crane is fed up with the way life has treated her. She has to meet her lover Sam in lunch breaks," +
                    "and they cannot get married because Sam has to give most of his money away in alimony. One Friday, Marion is trusted to bank forty thousand dollars by her employer." +
                    "Seeing the opportunity to take the money and start a new life, Marion leaves town and heads towards Sam's California store." +
                    "Tired after the long drive and caught in a storm, she gets off the main highway and pulls into the Bates Motel." +
                    "The motel is managed by a quiet young man called Norman who seems to be dominated by his mother. Written by Col Needham",
                    Language = "English",
                    Country = "USA",
                    PhotoURL = "Psycho_(1960)_theatrical_poster.jpg"

                }, new Movie
                {
                    Id = 6,
                    Title = "2001: A Space Odyssey",
                    DirectorID = 4,
                    DirectorName = "Stanley Kubrick",
                    GenreID = 10,
                    GenreName = "Sci-fi",
                    YearOfRelease = new DateTime(1968, 5, 12, 1, 0, 0),
                    IMBDScore = 8.3,
                    Price = 9.99,
                    Description = "2001 is a story of evolution. Sometime in the distant past, someone or something nudged evolution by placing a monolith on Earth " +
                    "(presumably elsewhere throughout the universe as well). Evolution then enabled humankind to reach the moon's surface, where yet another monolith is found," +
                    "one that signals the monolith placers that humankind has evolved that far. Now a race begins between computers (HAL) and human (Bowman) to reach the monolith placers." +
                    "The winner will achieve the next step in evolution, whatever that may be. Written by Larry Cousins",
                    Language = "English",
                    Country = "USA",
                    PhotoURL = "2001_A_Space_Odyssey_(1968).png"

                }, new Movie
                {
                    Id = 7,
                    Title = "Pulp Fiction",
                    DirectorID = 5,
                    DirectorName = "Quentin Tarantino",
                    GenreID = 3,
                    GenreName = "Crime",
                    YearOfRelease = new DateTime(1994, 10, 14, 1, 0, 0),
                    IMBDScore = 8.9,
                    Price = 19.99,
                    Description = "Jules Winnfield (Samuel L. Jackson) and Vincent Vega (John Travolta) are two hit men who are out to retrieve a suitcase stolen from their employer," +
                    "mob boss Marsellus Wallace (Ving Rhames). Wallace has also asked Vincent to take his wife Mia (Uma Thurman) out a few days later when Wallace himself will be out of town." +
                    "Butch Coolidge (Bruce Willis) is an aging boxer who is paid by Wallace to lose his fight. The lives of these seemingly unrelated people are woven together comprising of a" +
                    "series of funny, bizarre and uncalled-for incidents. Written by Soumitra",
                    Language = "English",
                    Country = "USA",
                    PhotoURL = "Pulp_Fiction_(1994)_poster.jpg"

                }, new Movie
                {
                    Id = 8,
                    Title = "The Secret Life of Nikola Tesla",
                    DirectorID = 6,
                    DirectorName = "Krsto Papic",
                    GenreID = 5,
                    GenreName = "Drama",
                    YearOfRelease = new DateTime(1980, 2, 19, 1, 0, 0),
                    IMBDScore = 7.4,
                    Price = 9.99,
                    Description = "Life and times of Nikola Tesla, famous scientist whose inventions were stolen," +
                    "but whose greatest contribution to mankind remain a mystery to this day. Written by Dragan Antulov",
                    Language = "English",
                    Country = "Yugoslavia",
                    PhotoURL = "AL.jpg"

                }, new Movie
                {
                    Id = 9,
                    Title = "Kagemusha",
                    DirectorID = 10,
                    DirectorName = "Akira Kurosawa ",
                    GenreID = 5,
                    GenreName = "Drama",
                    YearOfRelease = new DateTime(1980, 10, 10, 1, 0, 0),
                    IMBDScore = 8.0,
                    Price = 4.99,
                    Description = "When a powerful warlord in medieval Japan dies, a poor thief recruited to impersonate him finds difficulty living up to his role and clashes " +
                    "with the spirit of the warlord during turbulent times in the kingdom. Written by Keith Loh",
                    Language = "Japanese",
                    Country = "Japan",
                    PhotoURL = "Kagemusha_poster.jpg"

                }, new Movie
                {
                    Id = 10,
                    Title = "Gladiator",
                    DirectorID = 9,
                    DirectorName = "Ridley Scott",
                    GenreID = 4,
                    GenreName = "Adventure",
                    YearOfRelease = new DateTime(2000, 5, 5, 1, 0, 0),
                    IMBDScore = 8.5,
                    Price = 9.99,
                    Description = "Maximus is a powerful Roman general, loved by the people and the aging Emperor, Marcus Aurelius. Before his death," +
                    "the Emperor chooses Maximus to be his heir over his own son, Commodus, and a power struggle leaves Maximus and his family condemned to death." +
                    "The powerful general is unable to save his family, and his loss of will allows him to get captured and put into the Gladiator games until he dies." +
                    "The only desire that fuels him now is the chance to rise to the top so that he will be able to look into the eyes of the man who will feel his revenge." +
                    "Written by Chris Terry",
                    Language = "English",
                    Country = "USA",
                    PhotoURL = "Gladiator_(2000_film_poster).png"

                }, new Movie
                {
                    Id = 11,
                    Title = "E.T. the Extra-Terrestria",
                    DirectorID = 1,
                    DirectorName = "Steven Spielberg",
                    GenreID = 6,
                    GenreName = "Fantasy",
                    YearOfRelease = new DateTime(1982, 6, 11, 1, 0, 0),
                    IMBDScore = 7.8,
                    Price = 11.99,
                    Description = "After a gentle alien becomes stranded on Earth, the being is discovered and befriended by a young boy named Elliott." +
                    "Bringing the extraterrestrial into his suburban California house, Elliott introduces E.T., as the alien is dubbed, to his brother and his little sister, Gertie," +
                    "and the children decide to keep its existence a secret. Soon, however, E.T. falls ill, resulting in government intervention and a dire situation for both Elliott and the alien." +
                    "Written by Jwelch5742",
                    Language = "English",
                    Country = "USA",
                    PhotoURL = "V1.jpg"

                }, new Movie
                {
                    Id = 12,
                    Title = "Jaws",
                    DirectorID = 1,
                    DirectorName = "Steven Spielberg",
                    GenreID = 9,
                    GenreName = "Adventure",
                    YearOfRelease = new DateTime(1975, 6, 20, 1, 0, 0),
                    IMBDScore = 8.4,
                    Price = 7.99,
                    Description = "It's a hot summer on Amity Island, a small community whose main business is its beaches. When new Sheriff Martin Brody discovers the remains of a shark attack" +
                    "victim, his first inclination is to close the beaches to swimmers. This doesn't sit well with Mayor Larry Vaughn and several of the local businessmen." +
                    "Brody backs down to his regret as that weekend a young boy is killed by the predator. The dead boy's mother puts out a bounty on the shark and Amity is soon swamped with" +
                    "amateur hunters and fisherman hoping to cash in on the reward. A local fisherman with much experience hunting sharks, Quint, offers to hunt down the creature for a hefty fee." +
                    "Soon Quint, Brody and Matt Hooper from the Oceanographic Institute are at sea hunting the Great White shark. As Brody succinctly surmises after their first encounter with the" +
                    "creature, they're going to need a bigger boat. Written by garykmcd",
                    Language = "English",
                    Country = "USA",
                    PhotoURL = "AL_.jpg"

                }, new Movie
                {
                    Id = 13,
                    Title = "Close Encounters of the Third Kind",
                    DirectorID = 1,
                    DirectorName = "Steven Spielberg",
                    GenreID = 10,
                    GenreName = "Sci-fi",
                    YearOfRelease = new DateTime(1977, 11, 14, 1, 0, 0),
                    IMBDScore = 7.6,
                    Price = 13.99,
                    Description = "Two parallel stories are told. In the first, a group of research scientists from a variety of backgrounds are investigating the strange appearance of items in" +
                    "remote locations, primarily desert regions. In continuing their investigation, one of the lead scientists, a Frenchman named Claude Lacombe," +
                    "incorporates the Kodály method of music education as a means of communication in their work. The response, in turn, at first baffles the researchers," +
                    "until American cartographer David Laughlin deciphers the meaning of the response. In the second, electric company lineman and family man Roy Neary and single mother" +
                    "Jillian Guiler are among some individuals in Muncie, Indiana who experience some paranormal activity before some flashes of bright lights in the sky, which they" +
                    "believe to be a UFO. Roy becomes obsessed with what he saw, unlike some others, especially in some form of authority, who refuse to acknowledge their belief that" +
                    "it was a UFO in not wanting to appear crazy.",
                    Language = "English",
                    Country = "USA",
                    PhotoURL = "99.jpg"

                }

            );
           base.OnModelCreating(builder);
        }
    }
}
