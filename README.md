# orcs-earn-badges
A GitHub action that tracks [orcs-have-issues](https://github.com/MikeAmputer/orcs-have-issues) game achievements and adds badges to a profile readme.

<a><img src="https://github.com/MikeAmputer/orcs-earn-badges/blob/master/img/newcomer.png" alt="Newcomer" title="Create a character issue" width="64"></a>
<a><img src="https://github.com/MikeAmputer/orcs-earn-badges/blob/master/img/reactions-bronze.png" alt="Reactions Bronze" title="Earn 5 heart emojis on your character issue" width="64"></a>
<a><img src="https://github.com/MikeAmputer/orcs-earn-badges/blob/master/img/reactions-silver.png" alt="Reactions Bronze" title="Earn 25 heart emojis on your character issue" width="64"></a>
<a><img src="https://github.com/MikeAmputer/orcs-earn-badges/blob/master/img/reactions-gold.png" alt="Reactions Bronze" title="Earn 100 heart emojis on your character issue" width="64"></a>

## Installation
Create a character in the [orcs-have-issues repository](https://github.com/MikeAmputer/orcs-have-issues) to earn your first badge.

Create a new repository named `YourLogin/YourLogin` on GitHub with a README.md file to [manage your profile readme](https://docs.github.com/en/account-and-profile/setting-up-and-managing-your-github-profile/customizing-your-profile/managing-your-profile-readme). Replace `YourLogin` with your GitHub username.

Edit README.md and add the following comment lines (badges will appear between them):

```
<!-- orcs-earn-badges -->
<!-- orcs-earn-badges -->
```

Create a new worflow in your repository at `.github/workflows/orcs-earn-badges.yml`:

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

[Generate a Personal Access Token](https://github.com/settings/personal-access-tokens/new) with `contents` permission. This token will be used to update the readme file.

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
