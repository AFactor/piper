require 'rubygems'
require 'rest-client'
require 'rspec'
require 'settingslogic'
include RSpec::Matchers
expanded_current_file_path = File.expand_path(File.dirname(__FILE__))

Dir.glob(File.join(expanded_current_file_path, "/*/*")).each do |file|
  require file
end

