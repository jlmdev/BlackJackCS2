# BlackJackCS2

## PEDAC

### Problem

- [ ] Create a deck of 52 standard playing cards
- [ ] House to be dealt 2 cards hidden from the player until house reveals hand
- [ ] Deal the player 2 cards, visible to the player
- [ ] The player should have a chance to hit until they decide to stop or they bust. At which point they lose regardless of the dealer's hand
- [ ] When the player stands, the house reveals its hand and hits until they have 17 or more
- [ ] If dealer goes over 21, the dealer loses
- [ ] The player should have 2 choices, hit and stand
- [ ] Consider Aces to always be worth 11, never 1
- [ ] The app should display the winner. For this mode, the winner is the one who gets closest to 21 without going over
- [ ] Ties go to the dealer
- [ ] There should be an option to play again.
- [ ] The cards should be shuffled at the start of each new game

### Examples

| Player 1 | Dealer |        Winner        |
| :------: | :----: | :------------------: |
|   A,K    |  9,8   |        Player        |
|  4,5,7   |  10,8  |        Dealer        |
|  3,9,Q   |  9,K   | Dealer (Player Bust) |

### Data Structure

|   Variable   |             Type             |                      Use                       |
| :----------: | :--------------------------: | :--------------------------------------------: |
|     deck     |         list \<card>         |                 Deck of Cards                  |
|    player    |            class             |                  Player class                  |
|    dealer    |            class             |                  Dealer class                  |
|     card     |            class             |                   Card Class                   |
|     face     |            string            |   instance of assignedSuit for creating deck   |
|     suit     |            string            |   instance of assignedFace for creating face   |
|    value     |             int              |       The value of a card based on face        |
|  PlayerName  |    Player Property string    |                 Name of Player                 |
|     Hand     | Player Property List \<card> |         Tracks cards in Player's hand          |
|  HandValue   |     Player Property int      | Tracks the value of the cards in Player's hand |
|     Suit     |     Card Property string     |                   Card Suit                    |
|     Face     |     Card Property string     |                   Card Face                    |
|    Value     |      Card Property int       |          Value of card based on face           |
| assignedSuit |        array string[]        | List of suits to be assigned in building deck  |
| assignedFace |        array string[]        | List of faces to be assigned in building deck  |
|   newCard    |             card             |            card to be added to deck            |

### Algorithm

- [ ] Create Card Class
- [ ] Create Player Class
- [ ] Main Program
- [ ] Prompt for player name
- [ ] Create play again loop
- [ ] Create Deck
- [ ] Shuffle Deck
- [ ] Create Player Instance
- [ ] Create Dealer Instance
- [ ] Deal Initial Dealer Cards
- [ ] Remove dealt cards from deck
- [ ] Deal initial Player Cards
- [ ] Remove dealt cards from deck
- [ ] Player Hit/Stand Loop
- [ ] Play dealer's hand
- [ ] Calculate Winner
- [ ] Prompt to play again
