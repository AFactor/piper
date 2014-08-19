require 'yaml'

class ConfigurationManager


  def self.load_config input,environment
    input = input.to_sym unless input.kind_of?(Symbol)
    config_file_location = File.join(File.dirname(__FILE__),"../../config/#{input}.yml")
    raise "No such file exists #{config_file_location}" unless File.exists?(config_file_location)
    raise "#{environment} - Environment not found in the specified yml file" unless YAML.load_file(config_file_location).keys.include? environment
    YAML.load_file(config_file_location)["#{environment}"]
  end

end