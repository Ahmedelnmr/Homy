# Homy

A real-estate listings platform (backend) for Egypt: owners and agents post properties for sale or rent, buyers search and save listings, and admins review content and manage users. Listings can be promoted through subscription packages.

## Features

- **Properties**: title, description, type, city, district, optional project, sale price and monthly rent price, area, rooms, bathrooms, floor, finishing type, purpose (sale/rent), map coordinates, address, agricultural flag, images and amenities.
- **Search and pagination** over listings (`PropertySearchDto`, pagination helpers).
- **Saved properties** per user.
- **Analytics counters** per listing: views, WhatsApp clicks, phone clicks.
- **Featured listings** with an expiry date.
- **Subscription packages** (for example bronze, silver, gold): price, duration (default 30 days), max properties, max featured, bump-up option.
- **Users and roles**: Owner, Agent, Admin. Phone-number login, optional WhatsApp number, verified/active flags, soft delete, profile image.
- **Admin area**: dashboard stats, property review, user search and management.
- **Master data**: cities, districts, projects, property types, amenities.
- Image upload helper.

## Tech stack

- C# on .NET 8
- ASP.NET Core with Identity (`User : IdentityUser`)
- Entity Framework Core (`HomeyContext`)
- AutoMapper-style mapping profiles (Admin, Auth, MasterData, Property, SavedProperty, Subscription)

## Project structure

| Project | Role |
| --- | --- |
| `Homy.Domin` | Entities (`Property`, `User`, `Package`, `City`, ...) |
| `Homy.Application` | DTOs, mapping profiles, helpers, DI setup |
| `Homy.Infurastructure` | `HomeyContext` and data access |
| `Homy.presentaion` | Web host and controllers |

## Getting started

Prerequisites: .NET 8 SDK and a database.

```bash
git clone https://github.com/Ahmedelnmr/Homy.git
cd Homy
# set your connection string and image upload settings
dotnet run --project Homy.presentaion
```

## Status

Early stage: only `HomeController` exists in the presentation project on the default branch. Feature code is in the domain and application layers.

## Author

Ahmed Elnmr, https://github.com/Ahmedelnmr
