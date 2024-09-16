# orcs-earn-badges
A GitHub action that tracks [orcs-have-issues](https://github.com/MikeAmputer/orcs-have-issues) game achievements and adds badges to a profile readme.

<table>
  <tr>
    <td width="90">
      <p align="center">
        <a><img src="https://github.com/MikeAmputer/orcs-earn-badges/blob/master/img/character/orc-1.png" alt="Level 1, Orc" title="Level 1, Orc" width="64"></a>
        <a><img src="https://github.com/MikeAmputer/orcs-earn-badges/blob/master/img/character/human-3.png" alt="Level 3, Orc" title="Level 3, Human" width="64"></a>
      </p>
    </td>
    <td>
      <img src="https://github.com/MikeAmputer/orcs-earn-badges/blob/master/img/newcomer.png" alt="Newcomer" title="Create a character issue" width="64">
      <img src="https://github.com/MikeAmputer/orcs-earn-badges/blob/master/img/reactions-bronze.png" alt="Reactions Bronze" title="Earn 5 heart emojis on your character issue" width="64">
      <img src="https://github.com/MikeAmputer/orcs-earn-badges/blob/master/img/reactions-silver.png" alt="Reactions Silver" title="Earn 25 heart emojis on your character issue" width="64">
      <img src="https://github.com/MikeAmputer/orcs-earn-badges/blob/master/img/reactions-gold.png" alt="Reactions Gold" title="Earn 100 heart emojis on your character issue" width="64">
      <img src="https://github.com/MikeAmputer/orcs-earn-badges/blob/master/img/cycles-bronze.png" alt="Cycles Bronze" title="Play for 10 days total" width="64">
      <img src="https://github.com/MikeAmputer/orcs-earn-badges/blob/master/img/cycles-silver.png" alt="Cycles Silver" title="Play for 100 days total" width="64">
      <img src="https://github.com/MikeAmputer/orcs-earn-badges/blob/master/img/cycles-gold.png" alt="Cycles Gold" title="Play for 365 days total" width="64">
      <img src="https://github.com/MikeAmputer/orcs-earn-badges/blob/master/img/craft-bronze.png" alt="Craft Bronze" title="Craft your first wargear" width="64">
      <img src="https://github.com/MikeAmputer/orcs-earn-badges/blob/master/img/craft-silver.png" alt="Craft Silver" title="Reach a combined wargear rank of 4" width="64">
      <img src="https://github.com/MikeAmputer/orcs-earn-badges/blob/master/img/craft-gold.png" alt="Craft Gold" title="Reach a combined wargear rank of 10" width="64">
      <img src="https://github.com/MikeAmputer/orcs-earn-badges/blob/master/img/spider-slayer-bronze.png" alt="Spider Slayer Bronze" title="Slay 10 spiders" width="64">
      <img src="https://github.com/MikeAmputer/orcs-earn-badges/blob/master/img/spider-slayer-silver.png" alt="Spider Slayer Silver" title="Slay 50 spiders" width="64">
      <img src="https://github.com/MikeAmputer/orcs-earn-badges/blob/master/img/spider-slayer-gold.png" alt="Spider Slayer Gold" title="Slay 250 spiders" width="64">
      <img src="https://github.com/MikeAmputer/orcs-earn-badges/blob/master/img/goblin-slayer-bronze.png" alt="Goblin Slayer Bronze" title="Slay 10 goblins" width="64">
      <img src="https://github.com/MikeAmputer/orcs-earn-badges/blob/master/img/goblin-slayer-silver.png" alt="Goblin Slayer Silver" title="Slay 50 goblins" width="64">
      <img src="https://github.com/MikeAmputer/orcs-earn-badges/blob/master/img/goblin-slayer-gold.png" alt="Goblin Slayer Gold" title="Slay 250 goblins" width="64">
      <img src="https://github.com/MikeAmputer/orcs-earn-badges/blob/master/img/bandit-slayer-bronze.png" alt="Bandit Slayer Bronze" title="Slay 10 bandits" width="64">
      <img src="https://github.com/MikeAmputer/orcs-earn-badges/blob/master/img/bandit-slayer-silver.png" alt="Bandit Slayer Silver" title="Slay 50 bandits" width="64">
      <img src="https://github.com/MikeAmputer/orcs-earn-badges/blob/master/img/bandit-slayer-gold.png" alt="Bandit Slayer Gold" title="Slay 250 bandits" width="64">
      <img src="https://github.com/MikeAmputer/orcs-earn-badges/blob/master/img/undead-slayer-bronze.png" alt="Undead Slayer Bronze" title="Slay 10 undead" width="64">
      <img src="https://github.com/MikeAmputer/orcs-earn-badges/blob/master/img/undead-slayer-silver.png" alt="Undead Slayer Silver" title="Slay 50 undead" width="64">
      <img src="https://github.com/MikeAmputer/orcs-earn-badges/blob/master/img/undead-slayer-gold.png" alt="Undead Slayer Gold" title="Slay 250 undead" width="64">
      <img src="https://github.com/MikeAmputer/orcs-earn-badges/blob/master/img/clean-issue.png" alt="Clean Issue" title="Keep your character issue clean" width="64">
    </td>
  </tr>
</table>

## Installation
Create a character in the [orcs-have-issues repository](https://github.com/MikeAmputer/orcs-have-issues) to earn your first badge.

Create a new repository named `YourLogin/YourLogin` on GitHub with a README.md file to [manage your profile readme](https://docs.github.com/en/account-and-profile/setting-up-and-managing-your-github-profile/customizing-your-profile/managing-your-profile-readme). Replace `YourLogin` with your GitHub username.

Edit README.md and add the following comment lines (badges will appear between them):

```
<!-- orcs-earn-badges -->
<!-- orcs-earn-badges -->
```

Create a new workflow (add file) in your repository at `.github/workflows/orcs-earn-badges.yml`:

```yml
name: Orcs Have Issues Badges

on:
  schedule:
    - cron: '30 1 * * *'
  workflow_dispatch:

jobs:
  update-badges:
    runs-on: ubuntu-latest
    steps:
      - name: Orcs Have Issues Profile Badges
        uses: MikeAmputer/orcs-earn-badges@v1
        with:
          token: ${{ secrets.REPOSITORY_TOKEN }}
```

This will automatically run the action daily at 1:30 UTC (1 hour after the game simulation), and will also let you to run it manually right now or any other time.

[Generate a Personal Access Token](https://github.com/settings/personal-access-tokens/new) with `contents` write permission. This token will be used to update the readme file.

<img src="https://github.com/user-attachments/assets/b0b22038-cfd0-44d1-a841-a06ae20a5927" width="40%"/>
<img src="https://github.com/user-attachments/assets/d6376280-3170-42ae-bb5c-0d5467d95549" width="60%"/>
<br><br>

Copy the token and navigate to `/settings/secrets/actions` of your repository.

<img src="https://github.com/user-attachments/assets/22a4f353-8593-4290-8a8d-82c5c15102c7" width="28%"/>
<br><br>

Create a new repository secret `REPOSITORY_TOKEN` with the value of the created token.

<img src="https://github.com/user-attachments/assets/b26b3c0b-d4b5-483e-968b-83c1eb631d40" width="60%"/>
<br><br>

To validate setup, navigate to the `/actions/workflows/orcs-earn-badges.yml` and run the workflow manually.

<img src="https://github.com/user-attachments/assets/25eb2968-dbda-4f55-8417-dc54354f930a" width="40%"/>
<br><br>

You can check the result in [my profile](https://github.com/MikeAmputer), and an example of installation in [my profile repository](https://github.com/MikeAmputer/MikeAmputer).
