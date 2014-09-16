class ApiConfig < Settingslogic
  source File.join(File.dirname(__FILE__),"../../config/config.yml")
  namespace ENV['ENVIRONMENT']


  def self.navigation_url
    self.base_url + self.navigation
  end

  def self.aisle_url
    self.base_url + self.product_listing + self.aisle
  end

end