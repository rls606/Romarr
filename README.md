# ️Romarr

Romarr is a game media manager for torrent users. It can helps you to find any game from multiple RSS Feed, sort them and check them. 
It can also run a Tinfoil server to grab all your games to your console.

# Main Features TODO

- [X] Init project
- [ ] Think about the domain
- [ ] Authentication
- [ ] Retrieve disk informations
  - [ ] Retrieve every .nsp games from a folder
    - [ ] Retrieve associated datas (name, cover, ...)
- [ ] Add Prowlarr compatibility
- [ ] Create a Tinfoil server
- [ ] Create docker image
  - [ ] Create DockerHub page
- [ ] Create GitHub Actions pipelines

# Domain entities

## Game

- ID (Guid)
- Platform
- Name
- Region
- Game Key
- Path
- Download Date

Retrieved on external API ?
- Cover URL
- Release Date

## User
*User will only there for authentication*

- Mail
- Password


