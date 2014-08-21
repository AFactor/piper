class ApiConfig < Settingslogic
  source File.join(File.dirname(__FILE__),"../../config/config.yml")
  namespace ENV['ENVIRONMENT']
end