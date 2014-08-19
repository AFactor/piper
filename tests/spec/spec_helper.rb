
require File.dirname(__FILE__) + '/../lib/env_variables'
require File.dirname(__FILE__) + '/../lib/requires'
RSpec.configure do |config|
  config.expect_with :rspec do |c|
    c.syntax = [:should, :expect]
  end
end
