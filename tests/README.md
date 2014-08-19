Installing and Running PAPI tests
====================================

##Installing RVM

To check if you already have RVM enter the following into your terminal:

`type rvm | head -1`

If you get `rvm is a function` all is well and you can skip the next step.

To install RVM enter the following into your terminal:

`\curl -sSL https://get.rvm.io | bash`

It will take a few mins to install. Quit and relaunch your terminal when its finished.

Next we need to install ruby version 2.0.0, enter the following into your terminal:

`rvm install 2.0.0`

Then you want to set ruby 2.0.0 as your default:

`rvm use 2.0.0 --default`

##Installing required gems

Go to the Horizon-Tests `gem install bundler` and then `bundle install`


These two commands will install all the gems that the tests need.

##Runing the tests

To run the tests run the following command:

`rake spec`

